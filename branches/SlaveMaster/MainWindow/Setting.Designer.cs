namespace MainWindow
{
    partial class Setting
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbxSerialPort = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.NumBaud = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numSalveID = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxParity = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxStopBits = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnEditExports = new System.Windows.Forms.Button();
            this.numericUpDown_remoteSalveID = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDown_Register_count = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDown_RemoteAddress = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.NumBaud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSalveID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_remoteSalveID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Register_count)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_RemoteAddress)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Master Serial Port Recive:";
            // 
            // cbxSerialPort
            // 
            this.cbxSerialPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSerialPort.FormattingEnabled = true;
            this.cbxSerialPort.Location = new System.Drawing.Point(198, 30);
            this.cbxSerialPort.Name = "cbxSerialPort";
            this.cbxSerialPort.Size = new System.Drawing.Size(219, 20);
            this.cbxSerialPort.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(342, 306);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(264, 306);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(156, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "Baud:";
            // 
            // NumBaud
            // 
            this.NumBaud.Location = new System.Drawing.Point(199, 176);
            this.NumBaud.Maximum = new decimal(new int[] {
            115200,
            0,
            0,
            0});
            this.NumBaud.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.NumBaud.Name = "NumBaud";
            this.NumBaud.Size = new System.Drawing.Size(219, 21);
            this.NumBaud.TabIndex = 6;
            this.NumBaud.Value = new decimal(new int[] {
            9200,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(132, 215);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "Salve ID:";
            // 
            // numSalveID
            // 
            this.numSalveID.Location = new System.Drawing.Point(199, 211);
            this.numSalveID.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numSalveID.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSalveID.Name = "numSalveID";
            this.numSalveID.Size = new System.Drawing.Size(219, 21);
            this.numSalveID.TabIndex = 8;
            this.numSalveID.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(144, 247);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "Parity:";
            // 
            // cbxParity
            // 
            this.cbxParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxParity.FormattingEnabled = true;
            this.cbxParity.Location = new System.Drawing.Point(199, 244);
            this.cbxParity.Name = "cbxParity";
            this.cbxParity.Size = new System.Drawing.Size(219, 20);
            this.cbxParity.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(132, 281);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "StopBits:";
            // 
            // cbxStopBits
            // 
            this.cbxStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxStopBits.FormattingEnabled = true;
            this.cbxStopBits.Location = new System.Drawing.Point(199, 277);
            this.cbxStopBits.Name = "cbxStopBits";
            this.cbxStopBits.Size = new System.Drawing.Size(219, 20);
            this.cbxStopBits.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(155, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "Slave Serial Port Export:";
            // 
            // BtnEditExports
            // 
            this.BtnEditExports.Location = new System.Drawing.Point(198, 144);
            this.BtnEditExports.Name = "BtnEditExports";
            this.BtnEditExports.Size = new System.Drawing.Size(218, 23);
            this.BtnEditExports.TabIndex = 14;
            this.BtnEditExports.Text = "Edit";
            this.BtnEditExports.UseVisualStyleBackColor = true;
            this.BtnEditExports.Click += new System.EventHandler(this.BtnEditExports_Click);
            // 
            // numericUpDown_master
            // 
            this.numericUpDown_remoteSalveID.Location = new System.Drawing.Point(198, 60);
            this.numericUpDown_remoteSalveID.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown_remoteSalveID.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_remoteSalveID.Name = "numericUpDown_master";
            this.numericUpDown_remoteSalveID.Size = new System.Drawing.Size(219, 21);
            this.numericUpDown_remoteSalveID.TabIndex = 16;
            this.numericUpDown_remoteSalveID.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(89, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 12);
            this.label7.TabIndex = 15;
            this.label7.Text = "Remote Salve ID:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(54, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 12);
            this.label8.TabIndex = 17;
            this.label8.Text = "Remote Register Count:";
            // 
            // numericUpDown_Register_count
            // 
            this.numericUpDown_Register_count.Location = new System.Drawing.Point(198, 90);
            this.numericUpDown_Register_count.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown_Register_count.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_Register_count.Name = "numericUpDown_Register_count";
            this.numericUpDown_Register_count.Size = new System.Drawing.Size(219, 21);
            this.numericUpDown_Register_count.TabIndex = 18;
            this.numericUpDown_Register_count.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(56, 118);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(131, 12);
            this.label9.TabIndex = 19;
            this.label9.Text = "Remote Start Address:";
            // 
            // numericUpDown_RemoteAddress
            // 
            this.numericUpDown_RemoteAddress.Location = new System.Drawing.Point(199, 116);
            this.numericUpDown_RemoteAddress.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDown_RemoteAddress.Name = "numericUpDown_RemoteAddress";
            this.numericUpDown_RemoteAddress.Size = new System.Drawing.Size(219, 21);
            this.numericUpDown_RemoteAddress.TabIndex = 20;
            this.numericUpDown_RemoteAddress.Value = new decimal(new int[] {
            40001,
            0,
            0,
            0});
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 341);
            this.Controls.Add(this.numericUpDown_RemoteAddress);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.numericUpDown_Register_count);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.numericUpDown_remoteSalveID);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.BtnEditExports);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbxStopBits);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbxParity);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numSalveID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NumBaud);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cbxSerialPort);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Setting";
            this.Text = "Setting";
            this.Load += new System.EventHandler(this.Setting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumBaud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSalveID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_remoteSalveID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Register_count)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_RemoteAddress)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxSerialPort;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown NumBaud;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numSalveID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxParity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxStopBits;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BtnEditExports;
        private System.Windows.Forms.NumericUpDown numericUpDown_remoteSalveID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDown_Register_count;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericUpDown_RemoteAddress;
    }
}