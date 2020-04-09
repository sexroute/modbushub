using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MainWindow.Properties;
using System.IO.Ports;
using static Modbus.ModbusSlaveSerial;
using Modbus;

namespace MainWindow
{
    public partial class Setting : Form
    {
        public Setting()
        {
            InitializeComponent();
        }
        private void loadSetting()
        {
            //1. com port
            string[] ports = SerialPort.GetPortNames();
            for (int i = 0; i < ports.Length; i++)
            {
                this.cbxSerialPort.Items.Add(ports[i]);
                String lstrPort = ports[i];
                if (lstrPort.Equals(Settings.Default.ComNumber,StringComparison.CurrentCultureIgnoreCase))
                {
                    this.cbxSerialPort.SelectedIndex = i;
                }
            }

            //2.baud rate
            this.NumBaud.Value = Settings.Default.Baud;
            //3.salve id
            this.numSalveID.Value = Settings.Default.SalveID;
            //4.Parity
            for (int i = 0; i < 5;i++ )
            {
                string lstrValue = Enum.GetName(typeof(Parity),(Parity)i);
                this.cbxParity.Items.Add(lstrValue);
                if (i==Settings.Default.Parity)
                {
                    this.cbxParity.SelectedIndex = i;
                }
            }
            //5.Stop Bit            
            for (int i = 0; i < 4;i++ )
            {
                string lstrValue = Enum.GetName(typeof(StopBits), (StopBits)i);
                this.cbxStopBits.Items.Add(lstrValue);
                if (i==Settings.Default.StopBits)
                {
                    this.cbxStopBits.SelectedIndex = i;
                }
            }

            //6.Byte Order
            if (Settings.Default.ByteOrder > (int)ByteOrder.DCBA)
            {
                Settings.Default.ByteOrder = (int)ByteOrder.DCBA;
            }

            if (Settings.Default.ByteOrder < (int)ByteOrder.CDAB)
            {
                Settings.Default.ByteOrder = (int)ByteOrder.CDAB;
            }

            this.cbxByteOrder.SelectedIndex = Settings.Default.ByteOrder;

            //             //com port export
            //            ports = SerialPort.GetPortNames();
            //             for (int i = 0; i < ports.Length; i++)
            //             {
            //                 this.cbxComPortExport.Items.Add(ports[i]);
            //                 String lstrPort = ports[i];
            //                 if (lstrPort.Equals(Settings.Default.ComNumberExport, StringComparison.CurrentCultureIgnoreCase))
            //                 {
            //                     this.cbxComPortExport.SelectedIndex = i;
            //                 }
            //             }

            //             ports = SerialPort.GetPortNames();
            //             for (int i = 0; i < ports.Length; i++)
            //             {
            //                 this.cbxComPortExport2.Items.Add(ports[i]);
            //                 String lstrPort = ports[i];
            //                 if (lstrPort.Equals(Settings.Default.ComNumberExport2, StringComparison.CurrentCultureIgnoreCase))
            //                 {
            //                     this.cbxComPortExport2.SelectedIndex = i;
            //                 }
            //             }
        }



        private void PrepareUI()
        {
            //1.bit order
            this.cbxByteOrder.Items.Clear();
            this.cbxByteOrder.Items.Add(ByteOrder.CDAB);
            this.cbxByteOrder.Items.Add(ByteOrder.ABCD);
            this.cbxByteOrder.Items.Add(ByteOrder.BADC);
            this.cbxByteOrder.Items.Add(ByteOrder.DCBA);
            this.cbxByteOrder.SelectedIndex = 0;
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            this.PrepareUI();
            this.loadSetting();
            this.CenterToParent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void btnSave_Click(object sender, EventArgs e)
        {
            Settings.Default.ComNumber = (string)this.cbxSerialPort.SelectedItem;
            Settings.Default.SalveID = (int)this.numSalveID.Value;
            Settings.Default.Baud = (int)this.NumBaud.Value;
            Settings.Default.Parity = this.cbxParity.SelectedIndex;
            Settings.Default.StopBits = this.cbxStopBits.SelectedIndex;
           
            Settings.Default.Save();
            Settings.Default.Reload();
            Settings.Default.ByteOrder = this.cbxByteOrder.SelectedIndex;
            if (Settings.Default.ByteOrder>(int)ByteOrder.DCBA)
            {
                Settings.Default.ByteOrder = (int)ByteOrder.DCBA;
            }

            if (Settings.Default.ByteOrder < (int)ByteOrder.CDAB)
            {
                Settings.Default.ByteOrder = (int)ByteOrder.CDAB;
            }
            this.Close();
        }

        private void BtnEditExports_Click(object sender, EventArgs e)
        {
            ExportPortsEdit loExports = new ExportPortsEdit();
            loExports.m_oPorts = Settings.Default.ComNumberExports;
            if (loExports.m_oPorts == null)
            {
                loExports.m_oPorts = new System.Collections.Specialized.StringDictionary();
            }
            loExports.ShowDialog(this);

            Settings.Default.ComNumberExports = loExports.m_oPorts;
        }
    }
}
