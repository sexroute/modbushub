using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Collections.Specialized;

namespace MainWindow
{
    public partial class ExportPortsEdit : Form
    {
        public ExportPortsEdit()
        {
            InitializeComponent();
        }
        public StringDictionary m_oPorts = new StringDictionary();
        public void UpdateUI()
        {
            String[] ports = SerialPort.GetPortNames();
            for (int i = 0; i < ports.Length; i++)
            {
                this.cbxPortExport.Items.Add(ports[i]);
                String lstrPort = ports[i];
            }

            foreach (String lstrKey in this.m_oPorts.Keys)
            {
                //                 ListViewItem loItem = new ListViewItem();
                //                 loItem.Text = this.m_oPorts.Keys.ToList<string>()[i];
                //                 loItem.Tag = loItem.Text;
                //                 this.listViewComPort.Items.Add(loItem);

                ListViewItem lpItem = new ListViewItem();
                lpItem.Text = lstrKey;
                lpItem.Tag = lpItem.Text;

                ListViewItem.ListViewSubItem lpSubItem = new ListViewItem.ListViewSubItem();
                lpSubItem.Text = this.m_oPorts[lstrKey];
                lpSubItem.Tag = lpSubItem.Text;
                lpItem.SubItems.Add(lpSubItem);

                this.listViewComPort.Items.Add(lpItem);
            }
        }
        private void ExportPortsEdit_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            this.UpdateUI();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.cbxPortExport.SelectedItem == null)
            {
                MessageBox.Show("Please select com port");
                return;
            }
            for (int i = 0; i < this.listViewComPort.Items.Count; i++)
            {
                if (this.cbxPortExport.SelectedText.Equals(this.listViewComPort.Items[i].Text,
                    StringComparison.CurrentCultureIgnoreCase))
                {
                    MessageBox.Show(this.cbxPortExport.SelectedItem.ToString() + " already added");
                    return;
                }
            }
            ListViewItem lpItem = new ListViewItem();
            lpItem.Text = this.cbxPortExport.SelectedItem.ToString();
            lpItem.Tag = lpItem.Text;

            ListViewItem.ListViewSubItem lpSubItem = new ListViewItem.ListViewSubItem();
            lpSubItem.Text = Modbus.ByteOrder.CDAB.ToString();
            lpItem.SubItems.Add(lpSubItem);

            this.listViewComPort.Items.Add(lpItem);
            // this.listViewComPort.Items.Add(this.cbxPortExport.SelectedItem.ToString());

        }

        private void ExportPortsEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.m_oPorts.Clear();
            for (int i = 0; i < this.listViewComPort.Items.Count; i++)
            {
                ListViewItem lpItem = this.listViewComPort.Items[i];
                this.m_oPorts.Add(lpItem.Text, lpItem.SubItems[1].Text);
            }
        }

        private void listViewComPort_MouseClick(object sender, MouseEventArgs e)
        {

        }
        private void DeleteSelected()
        {
            DialogResult lpResult = MessageBox.Show("Sure to Delete?", "Please Confirm", MessageBoxButtons.OKCancel);

            if (lpResult == DialogResult.OK)
            {
                this.listViewComPort.BeginUpdate();

                List<ListViewItem> loTobeDeleted = new List<ListViewItem>();
                for (int lnIndex = 0; lnIndex < this.listViewComPort.SelectedIndices.Count; lnIndex++)
                {
                    int lnItemToDelete = this.listViewComPort.SelectedIndices[lnIndex] - lnIndex;
                    loTobeDeleted.Add(this.listViewComPort.Items[lnItemToDelete]);
                }

                for (int i = 0; i < loTobeDeleted.Count; i++)
                {
                    this.listViewComPort.Items.Remove(loTobeDeleted[i]);
                }
                this.listViewComPort.EndUpdate();
                this.listViewComPort.SelectedIndices.Clear();
            }
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DeleteSelected();
        }

        public void ChangeToByteOrder(Modbus.ByteOrder anOrder)
        {
            this.listViewComPort.BeginUpdate();

            List<ListViewItem> loTobeChanged = new List<ListViewItem>();
            for (int lnIndex = 0; lnIndex < this.listViewComPort.SelectedIndices.Count; lnIndex++)
            {
                int lnItemToDelete = this.listViewComPort.SelectedIndices[lnIndex] - lnIndex;
                loTobeChanged.Add(this.listViewComPort.Items[lnItemToDelete]);
            }

            for (int i = 0; i < loTobeChanged.Count; i++)
            {
                this.listViewComPort.Items[i].SubItems[1].Text = anOrder.ToString();
            }
            this.listViewComPort.EndUpdate();
            this.listViewComPort.SelectedIndices.Clear();
        }

        private void tsCDAB_Click(object sender, EventArgs e)
        {
            this.ChangeToByteOrder(Modbus.ByteOrder.CDAB);
//             this.tsCDAB.Checked = true;
//             this.tsABCD.Checked = false;
//             this.tsBADC.Checked = false;
//             this.tsDCBA.Checked = false;
        }

        private void tsABCD_Click(object sender, EventArgs e)
        {
            this.ChangeToByteOrder(Modbus.ByteOrder.ABCD);
//             this.tsCDAB.Checked = false;
//             this.tsABCD.Checked = true;
//             this.tsBADC.Checked = false;
//             this.tsDCBA.Checked = false;
        }

        private void tsBADC_Click(object sender, EventArgs e)
        {
            this.ChangeToByteOrder(Modbus.ByteOrder.BADC);
        }

        private void tsDCBA_Click(object sender, EventArgs e)
        {
            this.ChangeToByteOrder(Modbus.ByteOrder.DCBA);
        }
    }
}
