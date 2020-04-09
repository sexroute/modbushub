using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace MainWindow
{
    public partial class ExportPortsEdit : Form
    {
        public ExportPortsEdit()
        {
            InitializeComponent();
        }
        public System.Collections.ArrayList m_oPorts = new System.Collections.ArrayList();
        public void UpdateUI()
        {
            String[] ports = SerialPort.GetPortNames();
            for (int i = 0; i < ports.Length; i++)
            {
                this.cbxPortExport.Items.Add(ports[i]);
                String lstrPort = ports[i];
            }

            for (int i = 0; i < this.m_oPorts.Count;i++ )
            {
                ListViewItem loItem = new ListViewItem();
                loItem.Text = this.m_oPorts[i].ToString();
                loItem.Tag = loItem.Text;
                this.listViewComPort.Items.Add(loItem);
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
            for (int i=0;i<this.listViewComPort.Items.Count;i++)
            {
                if (this.cbxPortExport.SelectedText.Equals(this.listViewComPort.Items[i].Text,
                    StringComparison.CurrentCultureIgnoreCase))
                {
                    MessageBox.Show(this.cbxPortExport.SelectedItem.ToString() +" already added");
                    return;
                }
            }
            this.listViewComPort.Items.Add(this.cbxPortExport.SelectedItem.ToString());
            
        }

        private void ExportPortsEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.m_oPorts.Clear();
            for (int i = 0; i < this.listViewComPort.Items.Count; i++)
            {
                this.m_oPorts.Add(this.listViewComPort.Items[i].Text);
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

                for (int i = 0; i < loTobeDeleted.Count;i++ )
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
    }
}
