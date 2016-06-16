Imports ScanAPIHelper
Imports System.Threading
Imports System.IO


Public Class Form1

    delegate sub SetTextCallback(text as String)

    Public Const FTR_ERROR_EMPTY_FRAME As Integer = 4306
    Public Const FTR_ERROR_MOVABLE_FINGER As Integer = &H20000001
    Public Const FTR_ERROR_NO_FRAME As Integer = &H20000002
    Public Const FTR_ERROR_USER_CANCELED As Integer = &H20000003
    Public Const FTR_ERROR_HARDWARE_INCOMPATIBLE As Integer = &H20000004
    Public Const FTR_ERROR_FIRMWARE_INCOMPATIBLE As Integer = &H20000005
    Public Const FTR_ERROR_INVALID_AUTHORIZATION_CODE As Integer = &H20000006

    Private m_hDevice As Device
    Private m_bCancelOperation As Boolean
    Private m_Frame() As Byte
    Private m_bScanning As Boolean
    Private m_ScanMode As Byte
    Private m_bIsLFDSupported As Boolean
    Private m_bExit As Boolean

    Public Class ComboBoxItem
        Dim m_String As String
        Dim m_InterfaceNumber As Integer

        Public Sub New(ByVal value As String, ByVal interfaceNumber As Integer)
            m_String = value
            m_InterfaceNumber = interfaceNumber
        End Sub

        Public Overrides Function ToString() As String
            Return m_String
        End Function

        Public ReadOnly Property interfaceNumber() As Integer
            Get
                Return m_InterfaceNumber
            End Get
        End Property
    End Class


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        m_btnOpenDevice.Enabled = False
        m_btnClose.Enabled = False
        m_grpParameters.Enabled = False
        m_grpTests.Enabled = False
        m_hDevice = Nothing
        m_ScanMode = 0
        m_bScanning = False
        m_bExit = False
        Dim defaultInterface As Integer
        Dim status() As FTRSCAN_INTERFACE_STATUS

        Try
            defaultInterface = ScanAPIHelper.Device.BaseInterface
            status = ScanAPIHelper.Device.GetInterfaces()
            For i As Integer = 0 To status.Length - 1
                If status(i) = FTRSCAN_INTERFACE_STATUS.FTRSCAN_INTERFACE_STATUS_CONNECTED Then
                    Dim index As Integer
                    index = m_cmbInterfaces.Items.Add(New ComboBoxItem(i.ToString(), i))
                    If (defaultInterface = i) Then
                        m_cmbInterfaces.SelectedIndex = index
                    End If
                End If
            Next i
        Catch ex As ScanAPIException
            ShowError(ex)
        End Try
        m_cmbDose.SelectedIndex = 3
        m_ScanMode = 0
    End Sub

    Private Sub m_btnOpenDevice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_btnOpenDevice.Click
        Try
            m_hDevice = New Device()
            m_hDevice.Open()
            ' gets devce parameters
            Dim version As VersionInfo = m_hDevice.VersionInformation
            m_lblApiVersion.Text = version.APIVersion.ToString()
            m_lblHardwareVersion.Text = version.HardwareVersion.ToString()
            m_lblFirmwareVersion.Text = version.FirmwareVersion.ToString()

            m_chkDetectFakeFinger.Checked = m_hDevice.DetectFakeFinger

            m_bIsLFDSupported = False
            Dim dinfo As DeviceInfo = m_hDevice.Information
            Select Case (dinfo.DeviceCompatibility)
                Case 0
                    m_lblCompatibility.Text = "FS80"
                    m_bIsLFDSupported = True
                Case 1
                    m_lblCompatibility.Text = "FS80"
                    m_bIsLFDSupported = True
                Case 4
                    m_lblCompatibility.Text = "FS80"
                    m_bIsLFDSupported = True
                Case 11
                    m_lblCompatibility.Text = "FS80"
                    m_bIsLFDSupported = True
                Case 5
                    m_lblCompatibility.Text = "FS88"
                    m_bIsLFDSupported = True
                Case 7
                    m_lblCompatibility.Text = "FS50"
                Case 8
                    m_lblCompatibility.Text = "FS60"
                Case 9
                    m_lblCompatibility.Text = "FS25"
                    m_bIsLFDSupported = True
                Case 10
                    m_lblCompatibility.Text = "FS10"
                Case 13
                    m_lblCompatibility.Text = "FS80H"
                    m_bIsLFDSupported = True
                Case 14
                    m_lblCompatibility.Text = "FS88H"
                    m_bIsLFDSupported = True
                Case 15
                    m_lblCompatibility.Text = "FS64"
                Case 16
                    m_lblCompatibility.Text = "FS26E"
                Case 17
                    m_lblCompatibility.Text = "FS80HS"
                Case 18
                    m_lblCompatibility.Text = "FS26"
                Case Else
                    m_lblCompatibility.Text = "Unknown device"
            End Select

            m_lblCurrentImageSize.Text = m_hDevice.ImageSize.ToString()
            m_grpParameters.Enabled = True
            m_grpTests.Enabled = True

            m_cmbInterfaces.Enabled = False
            m_btnOpenDevice.Enabled = False
            m_btnClose.Enabled = True
            m_chkDetectFakeFinger.Enabled = m_bIsLFDSupported
        Catch ex As ScanAPIException
            If m_hDevice IsNot Nothing Then
                m_hDevice.Dispose()
                m_hDevice = Nothing
                ShowError(ex)
            End If
        End Try
    End Sub

    Private Sub m_btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_btnClose.Click
        m_bCancelOperation = True
        m_hDevice.Dispose()
        m_hDevice = Nothing

        m_lblApiVersion.Text = String.Empty
        m_lblHardwareVersion.Text = String.Empty
        m_lblFirmwareVersion.Text = String.Empty

        m_chkDetectFakeFinger.Checked = False

        m_lblCompatibility.Text = String.Empty

        m_lblCurrentImageSize.Text = String.Empty

        m_picture.Image = Nothing

        m_grpParameters.Enabled = False
        m_grpTests.Enabled = False

        m_cmbInterfaces.Enabled = True
        m_btnOpenDevice.Enabled = True
        m_btnClose.Enabled = False
        m_btnSave.Enabled = False

    End Sub

    Private Sub m_cmbInterfaces_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_cmbInterfaces.SelectedIndexChanged
        If m_cmbInterfaces.SelectedIndex <> -1 Then
            Dim item As ComboBoxItem = m_cmbInterfaces.Items(m_cmbInterfaces.SelectedIndex)
            Try
                ScanAPIHelper.Device.BaseInterface = item.interfaceNumber
                m_btnOpenDevice.Enabled = True
            Catch ex As ScanAPIException
                ShowError(ex)
            End Try
        Else
            m_btnOpenDevice.Enabled = False
        End If
    End Sub

    Private Sub ShowError(ByRef ex As ScanAPIException)
        Dim szMessage As String
        Select Case (ex.ErrorCode)
            Case FTR_ERROR_EMPTY_FRAME
                szMessage = "Empty Frame"
            Case FTR_ERROR_MOVABLE_FINGER
                szMessage = "Movable Finger"
            Case FTR_ERROR_NO_FRAME
                szMessage = "Fake Finger"
            Case FTR_ERROR_HARDWARE_INCOMPATIBLE
                szMessage = "Incompatible Hardware"
            Case FTR_ERROR_FIRMWARE_INCOMPATIBLE
                szMessage = "Incompatible Firmware"
            Case FTR_ERROR_INVALID_AUTHORIZATION_CODE
                szMessage = "Invalid Authorization Code"
            Case Else
                szMessage = String.Format("Error code: {0}", ex.ErrorCode)
        End Select
        SetMessageText(szMessage)
    End Sub

    Private Sub SetMessageText(ByVal text As String)
        If m_bExit Then
            Exit Sub
        End If
        If (m_textMessage.InvokeRequired) Then
            Dim d As SetTextCallback = New SetTextCallback(AddressOf Me.SetMessageText)
            Me.Invoke(d, New Object() {text})
        Else
            Me.m_textMessage.Text = text
            Me.Update()
        End If
    End Sub

    Private Sub m_btnGetFrame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_btnGetFrame.Click
        If Not m_bScanning Then
            m_bCancelOperation = False
            m_btnGetFrame.Text = "Stop"
            m_btnSave.Enabled = False
            m_btnClose.Enabled = False
            Dim WorkerThread As Thread = New Thread(New ThreadStart(AddressOf CaptureThread))
            WorkerThread.Start()
        Else
            m_bCancelOperation = True
            m_btnGetFrame.Text = "Scan"
            m_btnClose.Enabled = True
            If m_Frame IsNot Nothing Then
                m_btnSave.Enabled = True
            End If
        End If
    End Sub

    Private Sub CaptureThread()
        m_bScanning = True
        While (Not m_bCancelOperation)
            GetFrame()
            If m_Frame IsNot Nothing Then
                Dim myFile As MyBitmapFile = New MyBitmapFile(m_hDevice.ImageSize.Width, m_hDevice.ImageSize.Height, m_Frame)
                Dim BmpStream As MemoryStream = New MemoryStream(myFile.BitmatFileData)
                Dim Bmp As Bitmap = New Bitmap(BmpStream)
                m_picture.Image = Bmp
            Else
                m_picture.Image = Nothing
            End If
            Thread.Sleep(10)
        End While
        m_bScanning = False
    End Sub

    Private Sub GetFrame()
        Try
            If m_ScanMode = 0 Then
                m_Frame = m_hDevice.GetFrame()
            Else
                m_Frame = m_hDevice.GetImage(m_ScanMode)
            End If
            SetMessageText("OK")
        Catch ex As ScanAPIException
            If m_Frame IsNot Nothing Then
                m_Frame = Nothing
                ShowError(ex)
            End If
        End Try
    End Sub


    Private Sub m_chkFrame_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_chkFrame.CheckedChanged
        If (m_chkFrame.Checked) Then
            m_ScanMode = 0
        Else
            m_ScanMode = m_cmbDose.SelectedIndex + 1
        End If
        m_cmbDose.Enabled = Not m_chkFrame.Checked
        If m_bIsLFDSupported Then
            m_chkDetectFakeFinger.Enabled = m_chkFrame.Checked
        Else
            m_chkDetectFakeFinger.Enabled = False
        End If
    End Sub

    Private Sub m_cmbDose_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_cmbDose.SelectedIndexChanged
        m_ScanMode = m_cmbDose.SelectedIndex + 1
    End Sub

    Private Sub m_chkDetectFakeFinger_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_chkDetectFakeFinger.CheckedChanged
        If m_hDevice IsNot Nothing Then
            m_hDevice.DetectFakeFinger = m_chkDetectFakeFinger.Checked
        End If
    End Sub

    Private Sub m_chkInvertImage_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_chkInvertImage.CheckedChanged
        If m_hDevice IsNot Nothing Then
            m_hDevice.InvertImage = m_chkInvertImage.Checked
        End If
    End Sub

    Private Sub m_btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_btnSave.Click
        Dim dlgSave As SaveFileDialog = New SaveFileDialog()
        dlgSave.Filter = "bmp files (*.bmp)|*.bmp|wsq files (*.wsq)|*.wsq"
        If dlgSave.ShowDialog() = DialogResult.OK Then
            If dlgSave.FilterIndex = 1 Then
                Dim myFile As MyBitmapFile = New MyBitmapFile(m_hDevice.ImageSize.Width, m_hDevice.ImageSize.Height, m_Frame)
                Dim file As FileStream = New FileStream(dlgSave.FileName, FileMode.Create)
                file.Write(myFile.BitmatFileData, 0, myFile.BitmatFileData.Length)
                file.Close()
                SetMessageText("Bitmap file is saved to " + dlgSave.FileName)
            Else
                Dim fBitRate As Single = 0.75  ' in the range of 0.75 - 2.25, lower value with higher compression rate
                Dim wsqImage() As Byte = m_hDevice.WSQ_FromRawImage(m_Frame, m_hDevice.ImageSize.Width, m_hDevice.ImageSize.Height, fBitRate)
                If wsqImage IsNot Nothing Then
                    Dim file As FileStream = New FileStream(dlgSave.FileName, FileMode.Create)
                    file.Write(wsqImage, 0, wsqImage.Length)
                    file.Close()
                    SetMessageText("WSQ file is saved to " + dlgSave.FileName)
                End If
            End If
        End If
    End Sub

    Private Sub Form1_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        m_bExit = True
        m_bCancelOperation = True
        If m_hDevice IsNot Nothing Then
            m_hDevice.Dispose()
            m_hDevice = Nothing
        End If
    End Sub
End Class
