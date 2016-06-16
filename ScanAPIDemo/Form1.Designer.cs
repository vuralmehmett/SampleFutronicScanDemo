namespace ScanAPIDemo
{
    partial class Form1
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
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.m_grpParameters = new System.Windows.Forms.GroupBox();
            this.m_chkInvertImage = new System.Windows.Forms.CheckBox();
            this.m_lblCurrentImageSize = new System.Windows.Forms.Label();
            this.m_chkDetectFakeFinger = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_cmbInterfaces = new System.Windows.Forms.ComboBox();
            this.m_btnOpenDevice = new System.Windows.Forms.Button();
            this.m_btnClose = new System.Windows.Forms.Button();
            this.m_btnGetFrame = new System.Windows.Forms.Button();
            this.m_grpTests = new System.Windows.Forms.GroupBox();
            this.m_textMessage = new System.Windows.Forms.TextBox();
            this.m_btnSave = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.m_cmbDose = new System.Windows.Forms.ComboBox();
            this.m_chkFrame = new System.Windows.Forms.CheckBox();
            this.m_picture = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_lblFirmwareVersion = new System.Windows.Forms.Label();
            this.m_lblCompatibility = new System.Windows.Forms.Label();
            this.m_lblHardwareVersion = new System.Windows.Forms.Label();
            this.m_lblApiVersion = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.m_grpParameters.SuspendLayout();
            this.m_grpTests.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_picture)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(9, 32);
            label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(83, 17);
            label7.TabIndex = 5;
            label7.Text = "Image size: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(288, 58);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(37, 17);
            label4.TabIndex = 4;
            label4.Text = "FW: ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(12, 27);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(59, 17);
            label5.TabIndex = 0;
            label5.Text = "Device: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(153, 57);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(39, 17);
            label3.TabIndex = 2;
            label3.Text = "HW: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(12, 57);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(37, 17);
            label2.TabIndex = 0;
            label2.Text = "API: ";
            // 
            // m_grpParameters
            // 
            this.m_grpParameters.Controls.Add(this.m_chkInvertImage);
            this.m_grpParameters.Controls.Add(this.m_lblCurrentImageSize);
            this.m_grpParameters.Controls.Add(label7);
            this.m_grpParameters.Controls.Add(this.m_chkDetectFakeFinger);
            this.m_grpParameters.Location = new System.Drawing.Point(16, 171);
            this.m_grpParameters.Margin = new System.Windows.Forms.Padding(4);
            this.m_grpParameters.Name = "m_grpParameters";
            this.m_grpParameters.Padding = new System.Windows.Forms.Padding(4);
            this.m_grpParameters.Size = new System.Drawing.Size(430, 115);
            this.m_grpParameters.TabIndex = 0;
            this.m_grpParameters.TabStop = false;
            this.m_grpParameters.Text = " Parameters ";
            // 
            // m_chkInvertImage
            // 
            this.m_chkInvertImage.AutoSize = true;
            this.m_chkInvertImage.Location = new System.Drawing.Point(257, 74);
            this.m_chkInvertImage.Name = "m_chkInvertImage";
            this.m_chkInvertImage.Size = new System.Drawing.Size(107, 21);
            this.m_chkInvertImage.TabIndex = 7;
            this.m_chkInvertImage.Text = "Invert Image";
            this.m_chkInvertImage.UseVisualStyleBackColor = true;
            this.m_chkInvertImage.CheckedChanged += new System.EventHandler(this.m_chkInvertImage_CheckedChanged);
            // 
            // m_lblCurrentImageSize
            // 
            this.m_lblCurrentImageSize.Location = new System.Drawing.Point(94, 32);
            this.m_lblCurrentImageSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.m_lblCurrentImageSize.Name = "m_lblCurrentImageSize";
            this.m_lblCurrentImageSize.Size = new System.Drawing.Size(316, 24);
            this.m_lblCurrentImageSize.TabIndex = 6;
            // 
            // m_chkDetectFakeFinger
            // 
            this.m_chkDetectFakeFinger.AutoSize = true;
            this.m_chkDetectFakeFinger.Location = new System.Drawing.Point(12, 74);
            this.m_chkDetectFakeFinger.Margin = new System.Windows.Forms.Padding(4);
            this.m_chkDetectFakeFinger.Name = "m_chkDetectFakeFinger";
            this.m_chkDetectFakeFinger.Size = new System.Drawing.Size(164, 21);
            this.m_chkDetectFakeFinger.TabIndex = 1;
            this.m_chkDetectFakeFinger.Text = "Live Finger Detection";
            this.m_chkDetectFakeFinger.UseVisualStyleBackColor = true;
            this.m_chkDetectFakeFinger.CheckedChanged += new System.EventHandler(this.OnDetectFakeFinger);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Default interface: ";
            // 
            // m_cmbInterfaces
            // 
            this.m_cmbInterfaces.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbInterfaces.FormattingEnabled = true;
            this.m_cmbInterfaces.Location = new System.Drawing.Point(141, 7);
            this.m_cmbInterfaces.Margin = new System.Windows.Forms.Padding(4);
            this.m_cmbInterfaces.Name = "m_cmbInterfaces";
            this.m_cmbInterfaces.Size = new System.Drawing.Size(79, 24);
            this.m_cmbInterfaces.TabIndex = 1;
            this.m_cmbInterfaces.SelectedIndexChanged += new System.EventHandler(this.m_cmbInterfaces_SelectedIndexChanged);
            // 
            // m_btnOpenDevice
            // 
            this.m_btnOpenDevice.Location = new System.Drawing.Point(238, 7);
            this.m_btnOpenDevice.Margin = new System.Windows.Forms.Padding(4);
            this.m_btnOpenDevice.Name = "m_btnOpenDevice";
            this.m_btnOpenDevice.Size = new System.Drawing.Size(100, 28);
            this.m_btnOpenDevice.TabIndex = 2;
            this.m_btnOpenDevice.Text = "Open";
            this.m_btnOpenDevice.UseVisualStyleBackColor = true;
            this.m_btnOpenDevice.Click += new System.EventHandler(this.OnOpenDevice);
            // 
            // m_btnClose
            // 
            this.m_btnClose.Location = new System.Drawing.Point(346, 7);
            this.m_btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.m_btnClose.Name = "m_btnClose";
            this.m_btnClose.Size = new System.Drawing.Size(100, 28);
            this.m_btnClose.TabIndex = 3;
            this.m_btnClose.Text = "Close";
            this.m_btnClose.UseVisualStyleBackColor = true;
            this.m_btnClose.Click += new System.EventHandler(this.OnCloseDevice);
            // 
            // m_btnGetFrame
            // 
            this.m_btnGetFrame.Location = new System.Drawing.Point(30, 102);
            this.m_btnGetFrame.Margin = new System.Windows.Forms.Padding(4);
            this.m_btnGetFrame.Name = "m_btnGetFrame";
            this.m_btnGetFrame.Size = new System.Drawing.Size(100, 28);
            this.m_btnGetFrame.TabIndex = 4;
            this.m_btnGetFrame.Text = "Scan";
            this.m_btnGetFrame.UseVisualStyleBackColor = true;
            this.m_btnGetFrame.Click += new System.EventHandler(this.OnTestGetFrame);
            // 
            // m_grpTests
            // 
            this.m_grpTests.Controls.Add(this.m_textMessage);
            this.m_grpTests.Controls.Add(this.m_btnSave);
            this.m_grpTests.Controls.Add(this.label6);
            this.m_grpTests.Controls.Add(this.m_cmbDose);
            this.m_grpTests.Controls.Add(this.m_btnGetFrame);
            this.m_grpTests.Controls.Add(this.m_chkFrame);
            this.m_grpTests.Location = new System.Drawing.Point(16, 323);
            this.m_grpTests.Margin = new System.Windows.Forms.Padding(4);
            this.m_grpTests.Name = "m_grpTests";
            this.m_grpTests.Padding = new System.Windows.Forms.Padding(4);
            this.m_grpTests.Size = new System.Drawing.Size(430, 185);
            this.m_grpTests.TabIndex = 5;
            this.m_grpTests.TabStop = false;
            this.m_grpTests.Text = "Operations";
            // 
            // m_textMessage
            // 
            this.m_textMessage.Location = new System.Drawing.Point(12, 147);
            this.m_textMessage.Name = "m_textMessage";
            this.m_textMessage.Size = new System.Drawing.Size(407, 22);
            this.m_textMessage.TabIndex = 11;
            // 
            // m_btnSave
            // 
            this.m_btnSave.Enabled = false;
            this.m_btnSave.Location = new System.Drawing.Point(257, 102);
            this.m_btnSave.Name = "m_btnSave";
            this.m_btnSave.Size = new System.Drawing.Size(100, 28);
            this.m_btnSave.TabIndex = 10;
            this.m_btnSave.Text = "Save";
            this.m_btnSave.UseVisualStyleBackColor = true;
            this.m_btnSave.Click += new System.EventHandler(this.m_btnSave_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(233, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Dose:";
            // 
            // m_cmbDose
            // 
            this.m_cmbDose.Enabled = false;
            this.m_cmbDose.FormattingEnabled = true;
            this.m_cmbDose.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.m_cmbDose.Location = new System.Drawing.Point(287, 36);
            this.m_cmbDose.Name = "m_cmbDose";
            this.m_cmbDose.Size = new System.Drawing.Size(77, 24);
            this.m_cmbDose.TabIndex = 8;
            this.m_cmbDose.SelectedIndexChanged += new System.EventHandler(this.m_cmbDose_SelectedIndexChanged);
            // 
            // m_chkFrame
            // 
            this.m_chkFrame.AutoSize = true;
            this.m_chkFrame.Checked = true;
            this.m_chkFrame.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkFrame.Location = new System.Drawing.Point(12, 39);
            this.m_chkFrame.Name = "m_chkFrame";
            this.m_chkFrame.Size = new System.Drawing.Size(70, 21);
            this.m_chkFrame.TabIndex = 7;
            this.m_chkFrame.Text = "Frame";
            this.m_chkFrame.UseVisualStyleBackColor = true;
            this.m_chkFrame.CheckedChanged += new System.EventHandler(this.m_chkFrame_CheckedChanged);
            // 
            // m_picture
            // 
            this.m_picture.Location = new System.Drawing.Point(468, 7);
            this.m_picture.Margin = new System.Windows.Forms.Padding(4);
            this.m_picture.Name = "m_picture";
            this.m_picture.Size = new System.Drawing.Size(362, 518);
            this.m_picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_picture.TabIndex = 6;
            this.m_picture.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_lblFirmwareVersion);
            this.groupBox2.Controls.Add(label4);
            this.groupBox2.Controls.Add(this.m_lblCompatibility);
            this.groupBox2.Controls.Add(this.m_lblHardwareVersion);
            this.groupBox2.Controls.Add(label5);
            this.groupBox2.Controls.Add(label3);
            this.groupBox2.Controls.Add(this.m_lblApiVersion);
            this.groupBox2.Controls.Add(label2);
            this.groupBox2.Location = new System.Drawing.Point(13, 59);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(433, 93);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Device && Version Information ";
            // 
            // m_lblFirmwareVersion
            // 
            this.m_lblFirmwareVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lblFirmwareVersion.Location = new System.Drawing.Point(321, 57);
            this.m_lblFirmwareVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.m_lblFirmwareVersion.Name = "m_lblFirmwareVersion";
            this.m_lblFirmwareVersion.Size = new System.Drawing.Size(92, 19);
            this.m_lblFirmwareVersion.TabIndex = 5;
            // 
            // m_lblCompatibility
            // 
            this.m_lblCompatibility.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lblCompatibility.Location = new System.Drawing.Point(67, 27);
            this.m_lblCompatibility.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.m_lblCompatibility.Name = "m_lblCompatibility";
            this.m_lblCompatibility.Size = new System.Drawing.Size(173, 19);
            this.m_lblCompatibility.TabIndex = 1;
            // 
            // m_lblHardwareVersion
            // 
            this.m_lblHardwareVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lblHardwareVersion.Location = new System.Drawing.Point(186, 57);
            this.m_lblHardwareVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.m_lblHardwareVersion.Name = "m_lblHardwareVersion";
            this.m_lblHardwareVersion.Size = new System.Drawing.Size(95, 19);
            this.m_lblHardwareVersion.TabIndex = 3;
            // 
            // m_lblApiVersion
            // 
            this.m_lblApiVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lblApiVersion.Location = new System.Drawing.Point(44, 57);
            this.m_lblApiVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.m_lblApiVersion.Name = "m_lblApiVersion";
            this.m_lblApiVersion.Size = new System.Drawing.Size(107, 19);
            this.m_lblApiVersion.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 549);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.m_picture);
            this.Controls.Add(this.m_grpTests);
            this.Controls.Add(this.m_btnClose);
            this.Controls.Add(this.m_btnOpenDevice);
            this.Controls.Add(this.m_cmbInterfaces);
            this.Controls.Add(this.m_grpParameters);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scan API Demo (C#)";
            this.Load += new System.EventHandler(this.OnFormLoad);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnFormClosed);
            this.m_grpParameters.ResumeLayout(false);
            this.m_grpParameters.PerformLayout();
            this.m_grpTests.ResumeLayout(false);
            this.m_grpTests.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_picture)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox m_grpParameters;
        private System.Windows.Forms.ComboBox m_cmbInterfaces;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button m_btnOpenDevice;
        private System.Windows.Forms.CheckBox m_chkDetectFakeFinger;
        private System.Windows.Forms.Button m_btnClose;
        private System.Windows.Forms.Button m_btnGetFrame;
        private System.Windows.Forms.GroupBox m_grpTests;
        private System.Windows.Forms.PictureBox m_picture;
        private System.Windows.Forms.Label m_lblCurrentImageSize;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label m_lblFirmwareVersion;
        private System.Windows.Forms.Label m_lblCompatibility;
        private System.Windows.Forms.Label m_lblHardwareVersion;
        private System.Windows.Forms.Label m_lblApiVersion;
        private System.Windows.Forms.CheckBox m_chkInvertImage;
        private System.Windows.Forms.ComboBox m_cmbDose;
        private System.Windows.Forms.CheckBox m_chkFrame;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button m_btnSave;
        private System.Windows.Forms.TextBox m_textMessage;
    }
}

