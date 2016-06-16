using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using SampleFutronicScanDemo.Common;
using ScanAPIHelper;

namespace SampleFutronicScanDemo
{
    class Program
    {
        private static Device m_hDevice;
        private static bool m_bCancelOperation;
        private static byte[] m_Frame;
        private static bool m_bScanning;
        private static byte m_ScanMode;
        private static bool m_bIsLFDSupported;
        private static bool m_bExit;

        private static Thread WorkerThread;

        [STAThread]
        static void Main(string[] args)
        {
            m_hDevice = new Device();
            m_hDevice.Open();

            VersionInfo version = m_hDevice.VersionInformation;

            Console.WriteLine(m_hDevice.VersionInformation);
            Console.WriteLine(version.APIVersion.ToString());
            Console.WriteLine(version.HardwareVersion.ToString());
            Console.WriteLine(version.FirmwareVersion.ToString());

            DeviceInfo dinfo = m_hDevice.Information;

            Console.WriteLine("Futronic" + "FS88");
            Console.WriteLine("Put your finger on the device");
            m_bIsLFDSupported = true;

            if (!m_bScanning)
            {
                m_bCancelOperation = false;
                WorkerThread = new Thread(new ThreadStart(CaptureThread));
                WorkerThread.Start();
            }
        }


        private static void CaptureThread()
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
                   
                }
                else
                    
                Thread.Sleep(10);
            }
            m_bScanning = false;
        }


        private static void GetFrame()
        {
            try
            {
                if (m_ScanMode == 0)
                    m_Frame = m_hDevice.GetFrame();
                else
                    m_Frame = m_hDevice.GetImage(m_ScanMode);
                Console.WriteLine("OK");

                SaveFingerTip();
            }
            catch (ScanAPIException ex)
            {
                if (m_Frame != null)
                    m_Frame = null;
                // Console.WriteLine(ex.Message);
            }
        }

        private static void SaveFingerTip()
        {
            SaveFileDialog dlgSave = new SaveFileDialog();
            dlgSave.Filter = "bmp files (*.bmp)|*.bmp|wsq files (*.wsq)|*.wsq";

            if (DialogResult.OK == (new Invoker(dlgSave).Invoke()))
            {
                if (dlgSave.FilterIndex == 1)
                {
                    MyBitmapFile myFile = new MyBitmapFile(m_hDevice.ImageSize.Width, m_hDevice.ImageSize.Height, m_Frame);
                    FileStream file = new FileStream(dlgSave.FileName, FileMode.Create);
                    file.Write(myFile.BitmatFileData, 0, myFile.BitmatFileData.Length);
                    file.Close();
                    Console.WriteLine("Bitmap file is saved to " + dlgSave.FileName);
                    Thread.Sleep(5000);
                    Application.Exit();
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
                        Console.WriteLine("WSQ file is saved to " + dlgSave.FileName);
                    }
                }
            }
        }

        public class Invoker
        {
            public CommonDialog InvokeDialog;
            private Thread InvokeThread;
            private DialogResult InvokeResult;

            public Invoker(CommonDialog dialog)
            {
                InvokeDialog = dialog;
                InvokeThread = new Thread(new ThreadStart(InvokeMethod));
                InvokeThread.SetApartmentState(ApartmentState.STA);
                InvokeResult = DialogResult.None;
            }

            public DialogResult Invoke()
            {
                InvokeThread.Start();
                InvokeThread.Join();
                return InvokeResult;
            }

            private void InvokeMethod()
            {
                InvokeResult = InvokeDialog.ShowDialog();
            }
        }

    }
}
