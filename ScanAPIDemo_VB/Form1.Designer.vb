<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim label4 As System.Windows.Forms.Label
        Dim label5 As System.Windows.Forms.Label
        Dim label3 As System.Windows.Forms.Label
        Dim label2 As System.Windows.Forms.Label
        Dim label7 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.m_textMessage = New System.Windows.Forms.TextBox
        Me.m_lblHardwareVersion = New System.Windows.Forms.Label
        Me.m_btnSave = New System.Windows.Forms.Button
        Me.label6 = New System.Windows.Forms.Label
        Me.m_cmbDose = New System.Windows.Forms.ComboBox
        Me.m_chkFrame = New System.Windows.Forms.CheckBox
        Me.m_lblFirmwareVersion = New System.Windows.Forms.Label
        Me.m_btnGetFrame = New System.Windows.Forms.Button
        Me.groupBox2 = New System.Windows.Forms.GroupBox
        Me.m_lblCompatibility = New System.Windows.Forms.Label
        Me.m_lblApiVersion = New System.Windows.Forms.Label
        Me.m_picture = New System.Windows.Forms.PictureBox
        Me.m_grpTests = New System.Windows.Forms.GroupBox
        Me.m_btnOpenDevice = New System.Windows.Forms.Button
        Me.m_btnClose = New System.Windows.Forms.Button
        Me.m_cmbInterfaces = New System.Windows.Forms.ComboBox
        Me.m_chkInvertImage = New System.Windows.Forms.CheckBox
        Me.m_grpParameters = New System.Windows.Forms.GroupBox
        Me.m_lblCurrentImageSize = New System.Windows.Forms.Label
        Me.m_chkDetectFakeFinger = New System.Windows.Forms.CheckBox
        Me.label1 = New System.Windows.Forms.Label
        label4 = New System.Windows.Forms.Label
        label5 = New System.Windows.Forms.Label
        label3 = New System.Windows.Forms.Label
        label2 = New System.Windows.Forms.Label
        label7 = New System.Windows.Forms.Label
        Me.groupBox2.SuspendLayout()
        CType(Me.m_picture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.m_grpTests.SuspendLayout()
        Me.m_grpParameters.SuspendLayout()
        Me.SuspendLayout()
        '
        'label4
        '
        label4.AutoSize = True
        label4.Location = New System.Drawing.Point(288, 58)
        label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        label4.Name = "label4"
        label4.Size = New System.Drawing.Size(37, 17)
        label4.TabIndex = 4
        label4.Text = "FW: "
        '
        'label5
        '
        label5.AutoSize = True
        label5.Location = New System.Drawing.Point(12, 27)
        label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        label5.Name = "label5"
        label5.Size = New System.Drawing.Size(59, 17)
        label5.TabIndex = 0
        label5.Text = "Device: "
        '
        'label3
        '
        label3.AutoSize = True
        label3.Location = New System.Drawing.Point(153, 57)
        label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        label3.Name = "label3"
        label3.Size = New System.Drawing.Size(39, 17)
        label3.TabIndex = 2
        label3.Text = "HW: "
        '
        'label2
        '
        label2.AutoSize = True
        label2.Location = New System.Drawing.Point(12, 57)
        label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        label2.Name = "label2"
        label2.Size = New System.Drawing.Size(37, 17)
        label2.TabIndex = 0
        label2.Text = "API: "
        '
        'label7
        '
        label7.AutoSize = True
        label7.Location = New System.Drawing.Point(9, 32)
        label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        label7.Name = "label7"
        label7.Size = New System.Drawing.Size(83, 17)
        label7.TabIndex = 5
        label7.Text = "Image size: "
        '
        'm_textMessage
        '
        Me.m_textMessage.Location = New System.Drawing.Point(12, 147)
        Me.m_textMessage.Name = "m_textMessage"
        Me.m_textMessage.Size = New System.Drawing.Size(407, 22)
        Me.m_textMessage.TabIndex = 11
        '
        'm_lblHardwareVersion
        '
        Me.m_lblHardwareVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.m_lblHardwareVersion.Location = New System.Drawing.Point(186, 57)
        Me.m_lblHardwareVersion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.m_lblHardwareVersion.Name = "m_lblHardwareVersion"
        Me.m_lblHardwareVersion.Size = New System.Drawing.Size(95, 19)
        Me.m_lblHardwareVersion.TabIndex = 3
        '
        'm_btnSave
        '
        Me.m_btnSave.Enabled = False
        Me.m_btnSave.Location = New System.Drawing.Point(257, 102)
        Me.m_btnSave.Name = "m_btnSave"
        Me.m_btnSave.Size = New System.Drawing.Size(100, 28)
        Me.m_btnSave.TabIndex = 10
        Me.m_btnSave.Text = "Save"
        Me.m_btnSave.UseVisualStyleBackColor = True
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(233, 39)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(45, 17)
        Me.label6.TabIndex = 9
        Me.label6.Text = "Dose:"
        '
        'm_cmbDose
        '
        Me.m_cmbDose.Enabled = False
        Me.m_cmbDose.FormattingEnabled = True
        Me.m_cmbDose.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7"})
        Me.m_cmbDose.Location = New System.Drawing.Point(287, 36)
        Me.m_cmbDose.Name = "m_cmbDose"
        Me.m_cmbDose.Size = New System.Drawing.Size(77, 24)
        Me.m_cmbDose.TabIndex = 8
        '
        'm_chkFrame
        '
        Me.m_chkFrame.AutoSize = True
        Me.m_chkFrame.Checked = True
        Me.m_chkFrame.CheckState = System.Windows.Forms.CheckState.Checked
        Me.m_chkFrame.Location = New System.Drawing.Point(12, 39)
        Me.m_chkFrame.Name = "m_chkFrame"
        Me.m_chkFrame.Size = New System.Drawing.Size(70, 21)
        Me.m_chkFrame.TabIndex = 7
        Me.m_chkFrame.Text = "Frame"
        Me.m_chkFrame.UseVisualStyleBackColor = True
        '
        'm_lblFirmwareVersion
        '
        Me.m_lblFirmwareVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.m_lblFirmwareVersion.Location = New System.Drawing.Point(321, 57)
        Me.m_lblFirmwareVersion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.m_lblFirmwareVersion.Name = "m_lblFirmwareVersion"
        Me.m_lblFirmwareVersion.Size = New System.Drawing.Size(92, 19)
        Me.m_lblFirmwareVersion.TabIndex = 5
        '
        'm_btnGetFrame
        '
        Me.m_btnGetFrame.Location = New System.Drawing.Point(30, 102)
        Me.m_btnGetFrame.Margin = New System.Windows.Forms.Padding(4)
        Me.m_btnGetFrame.Name = "m_btnGetFrame"
        Me.m_btnGetFrame.Size = New System.Drawing.Size(100, 28)
        Me.m_btnGetFrame.TabIndex = 4
        Me.m_btnGetFrame.Text = "Scan"
        Me.m_btnGetFrame.UseVisualStyleBackColor = True
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.m_lblFirmwareVersion)
        Me.groupBox2.Controls.Add(label4)
        Me.groupBox2.Controls.Add(Me.m_lblCompatibility)
        Me.groupBox2.Controls.Add(Me.m_lblHardwareVersion)
        Me.groupBox2.Controls.Add(label5)
        Me.groupBox2.Controls.Add(label3)
        Me.groupBox2.Controls.Add(Me.m_lblApiVersion)
        Me.groupBox2.Controls.Add(label2)
        Me.groupBox2.Location = New System.Drawing.Point(14, 57)
        Me.groupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.groupBox2.Size = New System.Drawing.Size(433, 93)
        Me.groupBox2.TabIndex = 15
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Device && Version Information "
        '
        'm_lblCompatibility
        '
        Me.m_lblCompatibility.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.m_lblCompatibility.Location = New System.Drawing.Point(67, 27)
        Me.m_lblCompatibility.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.m_lblCompatibility.Name = "m_lblCompatibility"
        Me.m_lblCompatibility.Size = New System.Drawing.Size(173, 19)
        Me.m_lblCompatibility.TabIndex = 1
        '
        'm_lblApiVersion
        '
        Me.m_lblApiVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.m_lblApiVersion.Location = New System.Drawing.Point(44, 57)
        Me.m_lblApiVersion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.m_lblApiVersion.Name = "m_lblApiVersion"
        Me.m_lblApiVersion.Size = New System.Drawing.Size(107, 19)
        Me.m_lblApiVersion.TabIndex = 1
        '
        'm_picture
        '
        Me.m_picture.Location = New System.Drawing.Point(469, 5)
        Me.m_picture.Margin = New System.Windows.Forms.Padding(4)
        Me.m_picture.Name = "m_picture"
        Me.m_picture.Size = New System.Drawing.Size(362, 518)
        Me.m_picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.m_picture.TabIndex = 14
        Me.m_picture.TabStop = False
        '
        'm_grpTests
        '
        Me.m_grpTests.Controls.Add(Me.m_textMessage)
        Me.m_grpTests.Controls.Add(Me.m_btnSave)
        Me.m_grpTests.Controls.Add(Me.label6)
        Me.m_grpTests.Controls.Add(Me.m_cmbDose)
        Me.m_grpTests.Controls.Add(Me.m_btnGetFrame)
        Me.m_grpTests.Controls.Add(Me.m_chkFrame)
        Me.m_grpTests.Location = New System.Drawing.Point(17, 321)
        Me.m_grpTests.Margin = New System.Windows.Forms.Padding(4)
        Me.m_grpTests.Name = "m_grpTests"
        Me.m_grpTests.Padding = New System.Windows.Forms.Padding(4)
        Me.m_grpTests.Size = New System.Drawing.Size(430, 185)
        Me.m_grpTests.TabIndex = 13
        Me.m_grpTests.TabStop = False
        Me.m_grpTests.Text = "Operations"
        '
        'm_btnOpenDevice
        '
        Me.m_btnOpenDevice.Location = New System.Drawing.Point(239, 5)
        Me.m_btnOpenDevice.Margin = New System.Windows.Forms.Padding(4)
        Me.m_btnOpenDevice.Name = "m_btnOpenDevice"
        Me.m_btnOpenDevice.Size = New System.Drawing.Size(100, 28)
        Me.m_btnOpenDevice.TabIndex = 11
        Me.m_btnOpenDevice.Text = "Open"
        Me.m_btnOpenDevice.UseVisualStyleBackColor = True
        '
        'm_btnClose
        '
        Me.m_btnClose.Location = New System.Drawing.Point(347, 5)
        Me.m_btnClose.Margin = New System.Windows.Forms.Padding(4)
        Me.m_btnClose.Name = "m_btnClose"
        Me.m_btnClose.Size = New System.Drawing.Size(100, 28)
        Me.m_btnClose.TabIndex = 12
        Me.m_btnClose.Text = "Close"
        Me.m_btnClose.UseVisualStyleBackColor = True
        '
        'm_cmbInterfaces
        '
        Me.m_cmbInterfaces.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.m_cmbInterfaces.FormattingEnabled = True
        Me.m_cmbInterfaces.Location = New System.Drawing.Point(142, 5)
        Me.m_cmbInterfaces.Margin = New System.Windows.Forms.Padding(4)
        Me.m_cmbInterfaces.Name = "m_cmbInterfaces"
        Me.m_cmbInterfaces.Size = New System.Drawing.Size(79, 24)
        Me.m_cmbInterfaces.TabIndex = 10
        '
        'm_chkInvertImage
        '
        Me.m_chkInvertImage.AutoSize = True
        Me.m_chkInvertImage.Location = New System.Drawing.Point(257, 74)
        Me.m_chkInvertImage.Name = "m_chkInvertImage"
        Me.m_chkInvertImage.Size = New System.Drawing.Size(107, 21)
        Me.m_chkInvertImage.TabIndex = 7
        Me.m_chkInvertImage.Text = "Invert Image"
        Me.m_chkInvertImage.UseVisualStyleBackColor = True
        '
        'm_grpParameters
        '
        Me.m_grpParameters.Controls.Add(Me.m_chkInvertImage)
        Me.m_grpParameters.Controls.Add(Me.m_lblCurrentImageSize)
        Me.m_grpParameters.Controls.Add(label7)
        Me.m_grpParameters.Controls.Add(Me.m_chkDetectFakeFinger)
        Me.m_grpParameters.Location = New System.Drawing.Point(17, 169)
        Me.m_grpParameters.Margin = New System.Windows.Forms.Padding(4)
        Me.m_grpParameters.Name = "m_grpParameters"
        Me.m_grpParameters.Padding = New System.Windows.Forms.Padding(4)
        Me.m_grpParameters.Size = New System.Drawing.Size(430, 115)
        Me.m_grpParameters.TabIndex = 8
        Me.m_grpParameters.TabStop = False
        Me.m_grpParameters.Text = " Parameters "
        '
        'm_lblCurrentImageSize
        '
        Me.m_lblCurrentImageSize.Location = New System.Drawing.Point(94, 32)
        Me.m_lblCurrentImageSize.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.m_lblCurrentImageSize.Name = "m_lblCurrentImageSize"
        Me.m_lblCurrentImageSize.Size = New System.Drawing.Size(316, 24)
        Me.m_lblCurrentImageSize.TabIndex = 6
        '
        'm_chkDetectFakeFinger
        '
        Me.m_chkDetectFakeFinger.AutoSize = True
        Me.m_chkDetectFakeFinger.Location = New System.Drawing.Point(12, 74)
        Me.m_chkDetectFakeFinger.Margin = New System.Windows.Forms.Padding(4)
        Me.m_chkDetectFakeFinger.Name = "m_chkDetectFakeFinger"
        Me.m_chkDetectFakeFinger.Size = New System.Drawing.Size(164, 21)
        Me.m_chkDetectFakeFinger.TabIndex = 1
        Me.m_chkDetectFakeFinger.Text = "Live Finger Detection"
        Me.m_chkDetectFakeFinger.UseVisualStyleBackColor = True
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(13, 9)
        Me.label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(120, 17)
        Me.label1.TabIndex = 9
        Me.label1.Text = "Default interface: "
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(843, 530)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.m_picture)
        Me.Controls.Add(Me.m_grpTests)
        Me.Controls.Add(Me.m_btnOpenDevice)
        Me.Controls.Add(Me.m_btnClose)
        Me.Controls.Add(Me.m_cmbInterfaces)
        Me.Controls.Add(Me.m_grpParameters)
        Me.Controls.Add(Me.label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ScanAPI Demo (VB)"
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        CType(Me.m_picture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.m_grpTests.ResumeLayout(False)
        Me.m_grpTests.PerformLayout()
        Me.m_grpParameters.ResumeLayout(False)
        Me.m_grpParameters.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents m_textMessage As System.Windows.Forms.TextBox
    Private WithEvents m_lblHardwareVersion As System.Windows.Forms.Label
    Private WithEvents m_btnSave As System.Windows.Forms.Button
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents m_cmbDose As System.Windows.Forms.ComboBox
    Private WithEvents m_chkFrame As System.Windows.Forms.CheckBox
    Private WithEvents m_lblFirmwareVersion As System.Windows.Forms.Label
    Private WithEvents m_btnGetFrame As System.Windows.Forms.Button
    Private WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents m_lblCompatibility As System.Windows.Forms.Label
    Private WithEvents m_lblApiVersion As System.Windows.Forms.Label
    Private WithEvents m_picture As System.Windows.Forms.PictureBox
    Private WithEvents m_grpTests As System.Windows.Forms.GroupBox
    Private WithEvents m_btnOpenDevice As System.Windows.Forms.Button
    Private WithEvents m_btnClose As System.Windows.Forms.Button
    Private WithEvents m_cmbInterfaces As System.Windows.Forms.ComboBox
    Private WithEvents m_chkInvertImage As System.Windows.Forms.CheckBox
    Private WithEvents m_grpParameters As System.Windows.Forms.GroupBox
    Private WithEvents m_lblCurrentImageSize As System.Windows.Forms.Label
    Private WithEvents m_chkDetectFakeFinger As System.Windows.Forms.CheckBox
    Private WithEvents label1 As System.Windows.Forms.Label

End Class
