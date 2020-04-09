namespace MainWindow
{
    partial class ExportPortsEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cbxPortExport = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.listViewComPort = new System.Windows.Forms.ListView();
            this.ComPort = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clByteOrder = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsCDAB = new System.Windows.Forms.ToolStripMenuItem();
            this.tsABCD = new System.Windows.Forms.ToolStripMenuItem();
            this.tsBADC = new System.Windows.Forms.ToolStripMenuItem();
            this.tsDCBA = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxPortExport
            // 
            this.cbxPortExport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPortExport.FormattingEnabled = true;
            this.cbxPortExport.Location = new System.Drawing.Point(25, 13);
            this.cbxPortExport.Name = "cbxPortExport";
            this.cbxPortExport.Size = new System.Drawing.Size(207, 20);
            this.cbxPortExport.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(248, 13);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(107, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // listViewComPort
            // 
            this.listViewComPort.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ComPort,
            this.clByteOrder});
            this.listViewComPort.ContextMenuStrip = this.contextMenuStrip1;
            this.listViewComPort.HideSelection = false;
            this.listViewComPort.Location = new System.Drawing.Point(25, 48);
            this.listViewComPort.Name = "listViewComPort";
            this.listViewComPort.Size = new System.Drawing.Size(330, 167);
            this.listViewComPort.TabIndex = 2;
            this.listViewComPort.UseCompatibleStateImageBehavior = false;
            this.listViewComPort.View = System.Windows.Forms.View.Details;
            this.listViewComPort.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewComPort_MouseClick);
            // 
            // ComPort
            // 
            this.ComPort.Text = "Comport";
            // 
            // clByteOrder
            // 
            this.clByteOrder.Text = "ByteOrder";
            this.clByteOrder.Width = 115;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsCDAB,
            this.tsABCD,
            this.tsBADC,
            this.tsDCBA,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 136);
            // 
            // tsCDAB
            // 
            this.tsCDAB.Name = "tsCDAB";
            this.tsCDAB.Size = new System.Drawing.Size(180, 22);
            this.tsCDAB.Text = "ByteOrder CD AB";
            this.tsCDAB.Click += new System.EventHandler(this.tsCDAB_Click);
            // 
            // tsABCD
            // 
            this.tsABCD.Name = "tsABCD";
            this.tsABCD.Size = new System.Drawing.Size(180, 22);
            this.tsABCD.Text = "ByteOrder AB CD";
            this.tsABCD.Click += new System.EventHandler(this.tsABCD_Click);
            // 
            // tsBADC
            // 
            this.tsBADC.Name = "tsBADC";
            this.tsBADC.Size = new System.Drawing.Size(180, 22);
            this.tsBADC.Text = "ByteOrder BA DC";
            this.tsBADC.Click += new System.EventHandler(this.tsBADC_Click);
            // 
            // tsDCBA
            // 
            this.tsDCBA.Name = "tsDCBA";
            this.tsDCBA.Size = new System.Drawing.Size(180, 22);
            this.tsDCBA.Text = "ByteOrder DC BA";
            this.tsDCBA.Click += new System.EventHandler(this.tsDCBA_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteToolStripMenuItem.Text = "delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // ExportPortsEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 236);
            this.Controls.Add(this.listViewComPort);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cbxPortExport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ExportPortsEdit";
            this.Text = "ExportPortsEdit";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExportPortsEdit_FormClosing);
            this.Load += new System.EventHandler(this.ExportPortsEdit_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxPortExport;
        private System.Windows.Forms.Button btnAdd;
        public System.Windows.Forms.ListView listViewComPort;
        private System.Windows.Forms.ColumnHeader ComPort;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader clByteOrder;
        private System.Windows.Forms.ToolStripMenuItem tsCDAB;
        private System.Windows.Forms.ToolStripMenuItem tsDCBA;
        private System.Windows.Forms.ToolStripMenuItem tsBADC;
        private System.Windows.Forms.ToolStripMenuItem tsABCD;
    }
}