﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Modbus;
using System.Diagnostics;
using System.IO.Ports;
using MainWindow.Properties;
using SinaWeiBo4wm.UiThread;

namespace MainWindow
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            this.EmptyCache();
            this.UpdateUI();
            Settings.Default.Reload();
            Settings.Default.Save();
            this.RealStart();
        }

        private void listView1_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {

            if (this.Cache != null && e.ItemIndex >= m_nFirstItem
                && e.ItemIndex < m_nFirstItem + this.Cache.Length
                )
            {
                //A cache hit, so get the ListViewItem from the cache instead of making a new one.
                e.Item = m_oCache[e.ItemIndex - m_nFirstItem];

            }
            else
            {
                //A cache miss, so create a new ListViewItem and pass it back.
                int x = e.ItemIndex;

                if (x < this.PointLimit)
                {
                    ListViewItem loItem = MakeUpItem(x);

                    if (null != loItem)
                    {
                        e.Item = loItem;
                    }

                }


            }
        }

        private void listView1_VirtualItemsSelectionRangeChanged(object sender, ListViewVirtualItemsSelectionRangeChangedEventArgs e)
        {

        }

        private void listView1_CacheVirtualItems(object sender, CacheVirtualItemsEventArgs e)
        {
            //We've gotten a request to refresh the cache.
            //First check if it's really neccesary.
            if (this.Cache != null
                && e.StartIndex >= m_nFirstItem
                && e.EndIndex <= m_nFirstItem + this.Cache.Length)
            {
                //If the newly requested cache is a subset of the old cache, 
                //no need to rebuild everything, so do nothing.
                return;
            }

            //Now we need to rebuild the cache.
            this.m_nFirstItem = e.StartIndex;
            int length = e.EndIndex - e.StartIndex + 1; //indexes are inclusive

            this.Cache = new ListViewItem[length];

            //Fill the cache with the appropriate ListViewItems.
            int lnItemIndex = 0;

            for (int i = 0; i < length; i++)
            {
                lnItemIndex = (i + m_nFirstItem);

                if (lnItemIndex >= this.PointLimit)
                {
                    continue;
                }

                ListViewItem loItem = MakeUpItem(lnItemIndex);

                if (null != loItem && this.Cache != null)
                {
                    m_oCache[i] = loItem;
                }
            }
        }

        private void listView1_SearchForVirtualItem(object sender, SearchForVirtualItemEventArgs e)
        {
            double x = 0;
            if (Double.TryParse(e.Text, out x)) //check if this is a valid search
            {
                x = Math.Sqrt(x);
                x = Math.Round(x);
                e.Index = (int)x;

            }
        }

        private ListViewItem MakeUpItem(int anIndex)
        {
            if (null == this.m_oModBus)
            {
                return null;
            }
            if (anIndex < this.PointLimit)
            {
                Datastore loDataSource = this.m_oModBus.ModbusDB.Single(x => x.UnitID == Settings.Default.SalveID);

                string lstrHoldingValue = loDataSource.HoldingRegisters[anIndex] + "";
                string lstrInputValue = loDataSource.InputRegisters[anIndex] + "";
                string lstrCoilsValue = loDataSource.Coils[anIndex] + "";
                string lstrDiscreteValue = loDataSource.DiscreteInputs[anIndex] + "";

                ListViewItem aoTreeItem = new ListViewItem(anIndex + "");

                aoTreeItem.SubItems.Add(lstrHoldingValue);
                aoTreeItem.SubItems.Add(lstrInputValue);
                aoTreeItem.SubItems.Add(lstrCoilsValue);
                aoTreeItem.SubItems.Add(lstrDiscreteValue);

                return aoTreeItem;
            }

            return null;

        }
        private void EmptyCache()
        {
            this.Cache = null;
        }
        private void UpdateUI()
        {
            try
            {
                if (this.ServerStarted)
                {
                    this.listView1.VirtualListSize = this.PointLimit;
                }
                else
                {
                    this.listView1.VirtualListSize = 0;
                }

                this.listView1.Refresh();
            }
            catch (System.Exception ex)
            {

            }
        }
        private ListViewItem[] m_oCache;           //array to cache items for the virtual list
        public ListViewItem[] Cache
        {
            get { return m_oCache; }
            set { m_oCache = value; }
        }
        private int m_nFirstItem = 0;              //stores the index of the first item in the cache
        int m_nPointLimit = 1000;

        public int PointLimit
        {
            get { return m_nPointLimit; }
            set { m_nPointLimit = value; }
        }
        public ModbusMasterSerial m_oModBus = null;
        public Modbus.ModbusMasterSerial ModBus
        {
            get { return m_oModBus; }
            set { m_oModBus = value; }
        }

 //      public ModbusSlave m_oModbusExport = null;
//         public Modbus.ModbusSlave ModbusExport
//         {
//             get { return m_oModbusExport; }
//             set { m_oModbusExport = value; }
//         }

        public List<Modbus.ModbusSlave> m_oModbusExports = new List<Modbus.ModbusSlave>();
        public List<ModbusSlave> ModbusExports
        {
            get { return m_oModbusExports; }
            set { m_oModbusExports = value; }
        }
//         public ModbusSlave m_oModbusExport2 = null;
//         public Modbus.ModbusSlave ModbusExport2
//         {
//             get { return m_oModbusExport2; }
//             set { m_oModbusExport2 = value; }
//         }
        public Boolean m_bServerStarted = false;
        public System.Boolean ServerStarted
        {
            get { return m_bServerStarted; }
            set { m_bServerStarted = value; }
        }
        public string m_strError = "";
        public string Error
        {
            get { return m_strError; }
            set { m_strError = value; }
        }
        private Boolean StartModBus()
        {
            if (this.ServerStarted)
            {
                return false;
            }
            if (Settings.Default.ComNumberExports == null)
            {
                return false;
            }

            String lstrCom = Settings.Default.ComNumber;
            if (String.IsNullOrEmpty(lstrCom.Trim()))
            {
                MessageBox.Show("Source com port must be specified");
                return false;
            }
            int lnBaudRate = Settings.Default.Baud;
            int lnDataBits = Settings.Default.DataBit;
            int lnParity = Settings.Default.Parity;
            if ((lnParity > (int)Parity.Space) || (lnParity < (int)Parity.None))
            {
                lnParity = (int)Parity.None;
            }
            Parity loParity = (Parity)lnParity;
            int lnStopBits = Settings.Default.StopBits;
            if ((lnStopBits > (int)StopBits.OnePointFive) || (lnStopBits < (int)StopBits.None))
            {
                lnStopBits = (int)StopBits.None;
            }
            StopBits loStopBits = (StopBits)lnStopBits;
            
            int lnSlaveId = Settings.Default.SalveID;
            
            int lnRemoteSalveID = Settings.Default.RemoteSalveID;
            
            Datastore ds = new Datastore((byte)lnSlaveId);
            
            this.m_oModBus = new ModbusMasterSerial(     new Datastore[] { ds },
                                                                                        ModbusSerialType.RTU,
                                                                                        lstrCom,
                                                                                        lnBaudRate,
                                                                                        lnDataBits,
                                                                                        loParity,
                                                                                        loStopBits,
                                                                                        Handshake.None);

            this.m_oModBus.SelfSalveID = (byte)lnSlaveId;

            this.m_oModBus.RemoteAddress = (ushort)Settings.Default.RemoteStartAddress;

            this.m_oModBus.RemoteRegisterCount = (ushort)Settings.Default.RemoteRegisterCount;

            this.m_oModbusExports = new List<Modbus.ModbusSlave>();
            
            for (int i = 0; i < Settings.Default.ComNumberExports.Count;i++ )
            {
                String lstrComport = Settings.Default.ComNumberExports[i].ToString();
                ModbusSlave loModbus = new ModbusSlaveSerial(new Datastore[] { ds },
                                                                                        ModbusSerialType.RTU,
                                                                                        lstrComport,
                                                                                        lnBaudRate,
                                                                                        lnDataBits,
                                                                                        loParity,
                                                                                        loStopBits,
                                                                                        Handshake.None);

                loModbus.ModbusDB = this.m_oModBus.ModbusDB;

                this.m_oModbusExports.Add(loModbus);
            }
            
//             lstrCom = Settings.Default.ComNumberExport;
//             this.m_oModbusExport = new ModbusSlaveSerial(new Datastore[] { ds },
//                                                                                         ModbusSerialType.RTU,
//                                                                                         lstrCom,
//                                                                                         lnBaudRate,
//                                                                                         lnDataBits,
//                                                                                         loParity,
//                                                                                         loStopBits,
//                                                                                         Handshake.None);
//             lstrCom = Settings.Default.ComNumberExports;
//             this.m_oModbusExport2= new ModbusSlaveSerial(new Datastore[] { ds },
//                                                                             ModbusSerialType.RTU,
//                                                                             lstrCom,
//                                                                             lnBaudRate,
//                                                                             lnDataBits,
//                                                                             loParity,
//                                                                             loStopBits,
//                                                                             Handshake.None);
// 
//             this.ModbusExport.ModbusDB = this.m_oModBus.ModbusDB;
//             this.ModbusExport2.ModbusDB = this.m_oModBus.ModbusDB;

            this.InitListView();
            // Start listen
            try
            {
                Boolean lbStartedError = false;
                for (int i = 0; i < this.m_oModbusExports.Count;i++ )
                {
                    if (!this.m_oModbusExports[i].StartListen())
                    {
                        lbStartedError = true;
                    }
                }
                if (!this.m_oModBus.StartWorking() || lbStartedError)
                {
                    Debug.Assert(false);
                    this.ServerStarted = false;
                    try
                    {
                        this.m_oModBus.StopWorking();
                    }
                    catch (System.Exception ex)
                    {
                    	
                    }
                    try
                    {
                        for (int i = 0; i < this.m_oModbusExports.Count;i++ )
                        {
                            this.m_oModbusExports[i].StopListen();
                        }
                    }
                    catch (System.Exception ex)
                    {
                    	
                    }

                   
                    return false;
                }
            }
            catch (System.Exception ex)
            {
                this.Error = ex.Message;
                Debug.Assert(false);
                this.ServerStarted = false;
                return false;
            }
            this.ServerStarted = true;
            return true;
        }

        private void RealStart()
        {
            if (this.StartModBus())
            {
                this.Timer.Start();
                this.timer1.Start();
                this.StartToolStripMenuItem.Enabled = false;
                this.StopToolStripMenuItem.Enabled = true;
            }
            else
            {
                if (this.m_oModBus != null)
                {
                    MessageBox.Show("Modbus Failed to Start reason:" + this.m_oModBus.ErrorMsg);
                }
                else
                {
                    MessageBox.Show("Modbus Failed to Start reason: cannot create Modbus object");
                }

            }
        }
        private void StartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.RealStart();
        }
        private void InitListView()
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.UpdateUI();
            if (this.Timer.ElapsedMilliseconds>5000)
            {
                ThreadUiController.Feed();
                this.Timer.Restart();
            }
        }
        Stopwatch m_oTimer = new Stopwatch();
        public System.Diagnostics.Stopwatch Timer
        {
            get { return m_oTimer; }
            set { m_oTimer = value; }
        }
        private void StopModBus()
        {
            if (this.ServerStarted && this.m_oModBus != null)
            {
                try
                {
                    this.m_oModBus.StopWorking();
                }
                catch (System.Exception ex)
                {

                }

                try
                {
                    for (int i = 0; i < this.m_oModbusExports.Count;i++ )
                    {
                        this.m_oModbusExports[i].StopListen();
                    }
                }
                catch (System.Exception ex)
                {

                }
                this.ServerStarted = false;
              
            }
        }

        private void StopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.StopModBus();
            this.Timer.Stop();
            this.timer1.Stop();
            this.StartToolStripMenuItem.Enabled = true;
            this.StopToolStripMenuItem.Enabled = false;

        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.m_bServerStarted)
            {
                e.Cancel = true;
                MessageBox.Show("Modbus is Running ,Please Stop First");
                return;
            }
            else
            {
                Application.Exit();
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Setting loSetting = new Setting();
            loSetting.ShowDialog(this);
            
        }
    }
}
