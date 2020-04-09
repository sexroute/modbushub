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
            this.label7 = new System.Windows.Forms.Label();
            this.cbxByteOrder = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.NumBaud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSalveID)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Serial Port Recive:";
            // 
            // cbxSerialPort
            // 
            this.cbxSerialPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSerialPort.FormattingEnabled = true;
            this.cbxSerialPort.Location = new System.Drawing.Point(163, 30);
            this.cbxSerialPort.Name = "cbxSerialPort";
            this.cbxSerialPort.Size = new System.Drawing.Size(219, 20);
            this.cbxSerialPort.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(274, 271);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(104, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(163, 271);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(104, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save and Close";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(122, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "Baud:";
            // 
            // NumBaud
            // 
            this.NumBaud.Location = new System.Drawing.Point(163, 96);
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
            this.NumBaud.TabIndex = 3;
            this.NumBaud.Value = new decimal(new int[] {
            9200,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(98, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "Salve ID:";
            // 
            // numSalveID
            // 
            this.numSalveID.Location = new System.Drawing.Point(163, 130);
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
            this.numSalveID.TabIndex = 4;
            this.numSalveID.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(110, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "Parity:";
            // 
            // cbxParity
            // 
            this.cbxParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxParity.FormattingEnabled = true;
            this.cbxParity.Location = new System.Drawing.Point(163, 164);
            this.cbxParity.Name = "cbxParity";
            this.cbxParity.Size = new System.Drawing.Size(219, 20);
            this.cbxParity.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(98, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "StopBits:";
            // 
            // cbxStopBits
            // 
            this.cbxStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxStopBits.FormattingEnabled = true;
            this.cbxStopBits.Location = new System.Drawing.Point(163, 197);
            this.cbxStopBits.Name = "cbxStopBits";
            this.cbxStopBits.Size = new System.Drawing.Size(219, 20);
            this.cbxStopBits.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "Serial Port Export:";
            // 
            // BtnEditExports
            // 
            this.BtnEditExports.Location = new System.Drawing.Point(163, 63);
            this.BtnEditExports.Name = "BtnEditExports";
            this.BtnEditExports.Size = new System.Drawing.Size(219, 20);
            this.BtnEditExports.TabIndex = 2;
            this.BtnEditExports.Text = "Edit";
            this.BtnEditExports.UseVisualStyleBackColor = true;
            this.BtnEditExports.Click += new System.EventHandler(this.BtnEditExports_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(2, 236);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(155, 12);
            this.label7.TabIndex = 15;
            this.label7.Text = "Remote Master Byte Order:";
            // 
            // cbxByteOrder
            // 
            this.cbxByteOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxByteOrder.FormattingEnabled = true;
            this.cbxByteOrder.Location = new System.Drawing.Point(163, 233);
            this.cbxByteOrder.Name = "cbxByteOrder";
            this.cbxByteOrder.Size = new System.Drawing.Size(219, 20);
            this.cbxByteOrder.TabIndex = 7;
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 314);
            this.Controls.Add(this.cbxByteOrder);
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
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbxByteOrder;
    }
}