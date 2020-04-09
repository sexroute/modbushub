using EricZhao.UiThread;
using Modbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainWindow
{
    public class Settings
    {
        public static Settings Default = new Settings();
       

        public string ComNumber = "COM1";
        public int SalveID = 1;
        public int Baud = 9600;
        public int Parity = 0; 
        public int StopBits = 1;   
        public int DataBit = 8;
        public global::Modbus.ModbusSerialType ModbusType
            = Modbus.ModbusSerialType.RTU;
        
        public int loglevel = 0;
               public global::System.Collections.Specialized.StringDictionary
            ComNumberExports = new System.Collections.Specialized.StringDictionary();
        public int ByteOrder = 0;

        IniFile m_oSettings = new IniFile("./settings.ini");
        public void Reload()
        {
            this.ComNumber = this.m_oSettings.IniReadStringValue("slave",
                "port", "COM1",true);
            this.SalveID = this.m_oSettings.IniReadIntValue("slave", "slave_id",
                1, true);
            this.Baud = this.m_oSettings.IniReadIntValue("slave", "baud_rate",
               9600, true);
            if(this.Baud<=0)
            {
                this.Baud = 9600;
            }

            this.Parity = this.m_oSettings.IniReadIntValue("slave", "parity",
               0, true);

            if (this.Parity <= 0)
            {
                this.Parity = 0;
            }
            this.StopBits = this.m_oSettings.IniReadIntValue("slave", "StopBits",
               1, true);

            if (this.StopBits <= 0)
            {
                this.StopBits = 0;
            }

            this.DataBit = this.m_oSettings.IniReadIntValue("slave", "data_bits",
               8, true);

            if (this.DataBit <= 5)
            {
                this.DataBit = 5;
            }

            if (this.DataBit > 8)
            {
                this.DataBit = 8;
            }

            int lnTemp =
                this.m_oSettings.IniReadIntValue("slave", "modbus_serial_type",
               (int)Modbus.ModbusSerialType.RTU, true);

            if(lnTemp<(int)Modbus.ModbusSerialType.RTU 
                || lnTemp>(int)Modbus.ModbusSerialType.ASCII)
            {
                lnTemp = (int)Modbus.ModbusSerialType.RTU;                
            }
            this.ModbusType = (Modbus.ModbusSerialType)lnTemp;
            int lnHubs = this.m_oSettings.IniReadIntValue("hub", "count",
               0, true);
            this.ComNumberExports.Clear();
            for (int i=0;i<lnHubs;i++)
            {
                String lstrPort = this.m_oSettings.IniReadStringValue("hub", 
                    "hub_"+i,
               "", true);
                if(String.IsNullOrWhiteSpace(lstrPort))
                {
                    continue;
                }
                String lstrByteOrder = this.m_oSettings.IniReadStringValue("hub", 
                    "byteorder_" + i,
               "CDBA", true);
               
                try
                {
                    ByteOrder lnTest;
                    if(Enum.TryParse<ByteOrder>(lstrByteOrder,out lnTest))
                    {
                        lstrByteOrder = lnTest.ToString();
                    }
                }catch(Exception e)
                {
                    lstrByteOrder = "CDAB";
                }

                this.ComNumberExports.Add(lstrPort, lstrByteOrder);
            }

        }

        public void Save()
        {
            this.m_oSettings.IniWriteStringValue("slave",
               "port", this.ComNumber);
            this.m_oSettings.iniWriteIntValue("slave", "slave_id",
                SalveID);
            this.m_oSettings.iniWriteIntValue("slave", "baud_rate",
               Baud);
            this.m_oSettings.iniWriteIntValue("slave", "parity",
               Baud);
            this.m_oSettings.iniWriteIntValue("slave", "parity",
               StopBits);
            this.m_oSettings.iniWriteIntValue("slave", "data_bits",
               StopBits);

            this.m_oSettings.iniWriteIntValue("slave", "modbus_serial_type",
               (int)ModbusType);

            this.m_oSettings.iniWriteIntValue("hub", "count",
               this.ComNumberExports.Count);

            int i = 0;
            foreach(String lstrKey in  this.ComNumberExports.Keys)
            {
              this.m_oSettings.IniWriteStringValue("hub",
                    "hub_" + i,
               lstrKey);

                String lstrByteOrder = this.ComNumberExports[lstrKey];
                    this.m_oSettings.IniWriteStringValue("hub",
                    "byteorder_" + i,
               lstrByteOrder);
               
                i++;
            }
        }
       
    }
}
