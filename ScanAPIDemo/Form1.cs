using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using ScanAPIHelper;
using System.Threading;
using System.Runtime.InteropServices;
using System.IO;

namespace ScanAPIDemo
{
    public partial class Form1 : Form
    {
        delegate void SetTextCallback(string text);

        const int FTR_ERROR_EMPTY_FRAME = 4306; /* ERROR_EMPTY */
        const int FTR_ERROR_MOVABLE_FINGER = 0x20000001;
        const int FTR_ERROR_NO_FRAME = 0x20000002;
        const int FTR_ERROR_USER_CANCELED = 0x20000003;
        const int FTR_ERROR_HARDWARE_INCOMPATIBLE = 0x20000004;
        const int FTR_ERROR_FIRMWARE_INCOMPATIBLE = 0x20000005;
        const int FTR_ERROR_INVALID_AUTHORIZATION_CODE = 0x20000006;

        /* Other return codes are Windows-compatible */
        const int ERROR_NO_MORE_ITEMS = 259;                // ERROR_NO_MORE_ITEMS
        const int ERROR_NOT_ENOUGH_MEMORY = 8;              // ERROR_NOT_ENOUGH_MEMORY
        const int ERROR_NO_SYSTEM_RESOURCES = 1450;         // ERROR_NO_SYSTEM_RESOURCES
        const int ERROR_TIMEOUT = 1460;                     // ERROR_TIMEOUT
        const int ERROR_NOT_READY = 21;                     // ERROR_NOT_READY
        const int ERROR_BAD_CONFIGURATION = 1610;           // ERROR_BAD_CONFIGURATION
        const int ERROR_INVALID_PARAMETER = 87;             // ERROR_INVALID_PARAMETER
        const int ERROR_CALL_NOT_IMPLEMENTED = 120;         // ERROR_CALL_NOT_IMPLEMENTED
        const int ERROR_NOT_SUPPORTED = 50;                 // ERROR_NOT_SUPPORTED
        const int ERROR_WRITE_PROTECT = 19;                 // ERROR_WRITE_PROTECT
        const int ERROR_MESSAGE_EXCEEDS_MAX_SIZE = 4336;    // ERROR_MESSAGE_EXCEEDS_MAX_SIZE

        private Device m_hDevice;
        private bool m_bCancelOperation;
        private byte[] m_Frame;
        private bool m_bScanning;
        private byte m_ScanMode;
        private bool m_bIsLFDSupported;
        private bool m_bExit;

        class ComboBoxItem
        {
            public ComboBoxItem(String value, int interfaceNumber)
            {
                m_String = value;
                m_InterfaceNumber = interfaceNumber;
            }

            public override string ToString()
            {
                return m_String;
            }

            public int interfaceNumber
            {
                get
                {
                    return m_InterfaceNumber;
                }
            }

            private String m_String;
            private int m_InterfaceNumber;
        }

        public Form1()
        {
            InitializeComponent();
            m_btnOpenDevice.Enabled = false;
            m_btnClose.Enabled = false;
            m_grpParameters.Enabled = false;
            m_grpTests.Enabled = false;
            m_hDevice = null;
            m_ScanMode = 0;
            m_bScanning = false;
            m_bExit = false;
        }

        private void OnFormLoad(object sender, EventArgs e)
        {
            try
            {
                int defaultInterface = ScanAPIHelper.Device.BaseInterface;
                FTRSCAN_INTERFACE_STATUS[] status = ScanAPIHelper.Device.GetInterfaces();
                for (int interfaceNumber = 0; interfaceNumber < status.Length; interfaceNumber++)
                {
                    if (status[interfaceNumber] == FTRSCAN_INTERFACE_STATUS.FTRSCAN_INTERFACE_STATUS_CONNECTED)
                    {
                        int index = m_cmbInterfaces.Items.Add( new ComboBoxItem( interfaceNumber.ToString(), interfaceNumber ) );
                        if (defaultInterface == interfaceNumber)
                        {
                            m_cmbInterfaces.SelectedIndex = index;
                        }
                    }
                }
            }
            catch( ScanAPIException ex)
            {
                ShowError( ex );
            }
            m_cmbDose.SelectedIndex = 3;
            m_ScanMode = 0;
        }

        private void m_cmbInterfaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_cmbInterfaces.SelectedIndex != -1)
            {
                ComboBoxItem item = (ComboBoxItem)m_cmbInterfaces.Items[ m_cmbInterfaces.SelectedIndex ];
                try
                {
                    ScanAPIHelper.Device.BaseInterface = item.interfaceNumber;
                    m_btnOpenDevice.Enabled = true;
                }
                catch (ScanAPIException ex)
                {
                    ShowError(ex);
                }
            }
            else
            {
                m_btnOpenDevice.Enabled = false;
            }

        }

        private void ShowError(ScanAPIException ex)
        {
            string szMessage;
            switch( ex.ErrorCode )
            {
            case FTR_ERROR_EMPTY_FRAME:
                szMessage = "Empty Frame";
                break;

            case FTR_ERROR_MOVABLE_FINGER:
                szMessage = "Movable Finger";
                break;

            case FTR_ERROR_NO_FRAME:
                szMessage = "Fake Finger";
                break;

            case FTR_ERROR_HARDWARE_INCOMPATIBLE:
                szMessage = "Incompatible Hardware";
                break;

            case FTR_ERROR_FIRMWARE_INCOMPATIBLE:
                szMessage = "Incompatible Firmware";
                break;

            case FTR_ERROR_INVALID_AUTHORIZATION_CODE:
                szMessage = "Invalid Authorization Code";
                break;

            case ERROR_NOT_ENOUGH_MEMORY:
                szMessage = "Error code ERROR_NOT_ENOUGH_MEMORY";
                break;

            case ERROR_NO_SYSTEM_RESOURCES:
                szMessage = "Error code ERROR_NO_SYSTEM_RESOURCES";
                break;

            case ERROR_TIMEOUT:
                szMessage = "Error code ERROR_TIMEOUT";
                break;

            case ERROR_NOT_READY:
                szMessage = "Error code ERROR_NOT_READY";
                break;

            case ERROR_BAD_CONFIGURATION:
                szMessage = "Error code ERROR_BAD_CONFIGURATION";
                break;

            case ERROR_INVALID_PARAMETER:
                szMessage = "Error code ERROR_INVALID_PARAMETER";
                break;

            case ERROR_CALL_NOT_IMPLEMENTED:
                szMessage = "Error code ERROR_CALL_NOT_IMPLEMENTED";
                break;

            case ERROR_NOT_SUPPORTED:
                szMessage = "Error code ERROR_NOT_SUPPORTED";
                break;

            case ERROR_WRITE_PROTECT:
                szMessage = "Error code ERROR_WRITE_PROTECT";
                break;

            case ERROR_MESSAGE_EXCEEDS_MAX_SIZE:
                szMessage = "Error code ERROR_MESSAGE_EXCEEDS_MAX_SIZE";
                break;

            default:
                szMessage = String.Format( "Error code: {0}", ex.ErrorCode );
                break;
            }
            SetMessageText( szMessage );
        }

        private void OnOpenDevice(object sender, EventArgs e)
        {
            Console.WriteLine("hello");
            try
            {
                m_hDevice = new Device();
                m_hDevice.Open();

                // gets devce parameters
                VersionInfo version = m_hDevice.VersionInformation;
                m_lblApiVersion.Text = version.APIVersion.ToString();
                m_lblHardwareVersion.Text = version.HardwareVersion.ToString();
                m_lblFirmwareVersion.Text = version.FirmwareVersion.ToString();

                m_chkDetectFakeFinger.Checked = m_hDevice.DetectFakeFinger;

                m_bIsLFDSupported = false;
                DeviceInfo dinfo = m_hDevice.Information;
                switch (dinfo.DeviceCompatibility)
                {
                    case 0:
                    case 1:
                    case 4:
                    case 11:
                        m_lblCompatibility.Text = "FS80";
                        m_bIsLFDSupported = true;
                        break;
                    case 5:
                        m_lblCompatibility.Text = "FS88";
                        m_bIsLFDSupported = true;
                        break;
                    case 7:
                        m_lblCompatibility.Text = "FS50";
                        break;
                    case 8:
                        m_lblCompatibility.Text = "FS60";
                        break;
                    case 9:
                        m_lblCompatibility.Text = "FS25";
                        m_bIsLFDSupported = true;
                        break;
                    case 10:
                        m_lblCompatibility.Text = "FS10";
                        break;
                    case 13:
                        m_lblCompatibility.Text = "FS80H";
                        m_bIsLFDSupported = true;
                        break;
                    case 14:
                        m_lblCompatibility.Text = "FS88H";
                        m_bIsLFDSupported = true;
                        break;
                    case 15:
                        m_lblCompatibility.Text = "FS64";
                        break;
                    case 16:
                        m_lblCompatibility.Text = "FS26E";
                        break;
                    case 17:
                        m_lblCompatibility.Text = "FS80HS";
                        break;
                    case 18:
                        m_lblCompatibility.Text = "FS26";
                        break;
                    default:
                        m_lblCompatibility.Text = "Unknown device";
                        break;
                }

                m_lblCurrentImageSize.Text = m_hDevice.ImageSize.ToString();

                m_grpParameters.Enabled = true;
                m_grpTests.Enabled = true;

                m_cmbInterfaces.Enabled = false;
                m_btnOpenDevice.Enabled = false;
                m_btnClose.Enabled = true;                
                m_chkDetectFakeFinger.Enabled = m_bIsLFDSupported;
            }
            catch( ScanAPIException ex )
            {
                if( m_hDevice != null )
                {
                    m_hDevice.Dispose();
                    m_hDevice = null;
                }
                ShowError(ex);
            }

        }

        private void OnDetectFakeFinger(object sender, EventArgs e)
        {
            if (m_hDevice != null)
            {
                m_hDevice.DetectFakeFinger = m_chkDetectFakeFinger.Checked;
            }
        }

        private void OnCloseDevice(object sender, EventArgs e)
        {
            m_bCancelOperation = true;
            Size size = m_hDevice.ImageSize;
            m_hDevice.Dispose();
            m_hDevice = null;

            m_lblApiVersion.Text = String.Empty;
            m_lblHardwareVersion.Text = String.Empty;
            m_lblFirmwareVersion.Text = String.Empty;

            m_chkDetectFakeFinger.Checked = false;

            m_lblCompatibility.Text = String.Empty;

            m_lblCurrentImageSize.Text = String.Empty;

            m_picture.Image = null;

            m_grpParameters.Enabled = false;
            m_grpTests.Enabled = false;

            m_cmbInterfaces.Enabled = true;
            m_btnOpenDevice.Enabled = true;
            m_btnClose.Enabled = false;
            m_btnSave.Enabled = false;
        }

        private void SetMessageText(string text)
        {
            if (m_bExit)
                return;
            if (this.m_textMessage.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(this.SetMessageText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.m_textMessage.Text = text;
                this.Update();
            }
        }

        [STAThread]
        private void GetFrame()
        {
            try
            {
                if (m_ScanMode == 0)
                    m_Frame = m_hDevice.GetFrame();
                else
                    m_Frame = m_hDevice.GetImage(m_ScanMode);
                SetMessageText("OK");
                Thread myth;
                myth = new Thread(new System.Threading.ThreadStart(CallSaveDialog));
                myth.ApartmentState = ApartmentState.STA;
                myth.Start();

            }
            catch (ScanAPIException ex)
            {
                if (m_Frame != null)
                    m_Frame = null;
                ShowError(ex);
            }
        }

        private void CallSaveDialog()
        {
            SaveFileDialog dlgSave = new SaveFileDialog();
            dlgSave.Filter = "bmp files (*.bmp)|*.bmp|wsq files (*.wsq)|*.wsq";
            if (dlgSave.ShowDialog() == DialogResult.OK)
            {
                if (dlgSave.FilterIndex == 1)
                {
                    MyBitmapFile myFile = new MyBitmapFile(m_hDevice.ImageSize.Width, m_hDevice.ImageSize.Height, m_Frame);
                    FileStream file = new FileStream(dlgSave.FileName, FileMode.Create);
                    file.Write(myFile.BitmatFileData, 0, myFile.BitmatFileData.Length);
                    file.Close();
                    SetMessageText("Bitmap file is saved to " + dlgSave.FileName);
                }
                else //wsq
                {
                    float fBitRate = 0.75f; // in the range of 0.75 - 2.25, lower value with higher compression rate
                    byte[] wsqImage = m_hDevice.WSQ_FromRawImage(m_Frame, m_hDevice.ImageSize.Width, m_hDevice.ImageSize.Height, fBitRate);
                    if (wsqImage != null)
                    {
                        FileStream file = new FileStream(dlgSave.FileName, FileMode.Create);
                        file.Write(wsqImage, 0, wsqImage.Length);
                        file.Close();
                        SetMessageText("WSQ file is saved to " + dlgSave.FileName);
                    }
                }
            }

        }

        private void OnTestGetFrame(object sender, EventArgs e)
        {
            if (!m_bScanning)
            {
                m_bCancelOperation = false;
                m_btnGetFrame.Text = "Stop";
                m_btnSave.Enabled = false;
                m_btnClose.Enabled = false;
                Thread WorkerThread = new Thread(new ThreadStart(CaptureThread));
                WorkerThread.Start();
            }
            else
            {
                m_bCancelOperation = true;
                m_btnGetFrame.Text = "Scan";
                m_btnClose.Enabled = true;
                if (m_Frame != null)
                    m_btnSave.Enabled = true;
            }
        }

        private void CaptureThread()
        {
            m_bScanning = true;
            while (!m_bCancelOperation)
            {
                GetFrame();
                if (m_Frame != null)
                {
                    MyBitmapFile myFile = new MyBitmapFile(m_hDevice.ImageSize.Width, m_hDevice.ImageSize.Height, m_Frame);
                    MemoryStream BmpStream = new MemoryStream(myFile.BitmatFileData);
                    Bitmap Bmp = new Bitmap(BmpStream);
                    m_picture.Image = Bmp;
                }
                else
                    m_picture.Image = null;
                Thread.Sleep(10);
            }
            m_bScanning = false;
        }

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            m_bExit = true;
            m_bCancelOperation = true;
            if (m_hDevice != null)
            {
                m_hDevice.Dispose();
                m_hDevice = null;
            }
        }

        private void m_btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlgSave = new SaveFileDialog();
            dlgSave.Filter = "bmp files (*.bmp)|*.bmp|wsq files (*.wsq)|*.wsq";
            if (dlgSave.ShowDialog() == DialogResult.OK)
            {
                if (dlgSave.FilterIndex == 1)
                {
                    MyBitmapFile myFile = new MyBitmapFile(m_hDevice.ImageSize.Width, m_hDevice.ImageSize.Height, m_Frame);
                    FileStream file = new FileStream(dlgSave.FileName, FileMode.Create);
                    file.Write(myFile.BitmatFileData, 0, myFile.BitmatFileData.Length);
                    file.Close();
                    SetMessageText("Bitmap file is saved to " + dlgSave.FileName);
                }
                else //wsq
                {
                    float fBitRate = 0.75f; // in the range of 0.75 - 2.25, lower value with higher compression rate
                    byte[] wsqImage = m_hDevice.WSQ_FromRawImage(m_Frame, m_hDevice.ImageSize.Width, m_hDevice.ImageSize.Height, fBitRate);
                    if (wsqImage != null)
                    {
                        FileStream file = new FileStream(dlgSave.FileName, FileMode.Create);
                        file.Write(wsqImage, 0, wsqImage.Length);
                        file.Close();
                        SetMessageText("WSQ file is saved to " + dlgSave.FileName);
                    }                        
                }
            }
        }

        private void m_chkInvertImage_CheckedChanged(object sender, EventArgs e)
        {
            if (m_hDevice != null)
            {
                m_hDevice.InvertImage = m_chkInvertImage.Checked;
            }
        }

        private void m_chkFrame_CheckedChanged(object sender, EventArgs e)
        {
            if (m_chkFrame.Checked)
                m_ScanMode = 0;
            else
                m_ScanMode = (byte)(m_cmbDose.SelectedIndex + 1);
            m_cmbDose.Enabled = (!m_chkFrame.Checked);
            m_chkDetectFakeFinger.Enabled = (m_bIsLFDSupported ? m_chkFrame.Checked : false );
        }

        private void m_cmbDose_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_ScanMode = (byte) (m_cmbDose.SelectedIndex + 1);
        }
    }
}
