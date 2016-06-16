using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using SampleFutronicScanDemo.Common;
using ScanAPIHelper;

namespace SampleFutronicScanDemo
{
    /// <summary>
    /// ScanApiHelper 'dll içerisinde kullanılan methodlar
    /// Open() --> Reader Open
    /// GetFrame() --> Get fingerprint from reader
    /// GetImage(ScanMode) --> Get image type to fingerprint
    /// ImageSize.Width, _fingerprintReader.ImageSize.Height, _frame --> Width , Height
    /// </summary>
    class Program
    {
        private static Device _fingerprintReader;
        private static bool _cancelOperation;
        private static byte[] _frame;
        private static bool _scanning;
        public static byte ScanMode;
        private static bool m_bIsLFDSupported;
        private static bool _exitApplication;
        private static Thread _workerThread;

        static void Main(string[] args)
        {
            _fingerprintReader = new Device();
            _fingerprintReader.Open();

            Console.WriteLine("Futronic" + "FS88");
            Console.WriteLine("Put your finger on the device");
            m_bIsLFDSupported = true;

            if (!_scanning)
            {
                _cancelOperation = false;
                _workerThread = new Thread(CaptureThread);
                _workerThread.Start();
            }
        }

        private static void CaptureThread()
        {
            _scanning = true;
            while (!_cancelOperation)
            {
                GetFrame();
            }
            _scanning = false;
        }

        private static void GetFrame()
        {
            try
            {
                if (ScanMode == 0)
                    _frame = _fingerprintReader.GetFrame();
                else
                    _frame = _fingerprintReader.GetImage(ScanMode);
                Console.WriteLine("OK");

                SaveFingerTip();
            }
            catch (ScanAPIException ex)
            {
                if (_frame != null)
                    _frame = null;
            }
        }

        private static void SaveFingerTip()
        {
            var dlgSave = new SaveFileDialog { Filter = "bmp files (*.bmp)|*.bmp|wsq files (*.wsq)|*.wsq" };

            if (DialogResult.OK == (new Invoker(dlgSave).Invoke()))
            {
                var myFile = new MyBitmapFile(_fingerprintReader.ImageSize.Width, _fingerprintReader.ImageSize.Height, _frame);
                var file = new FileStream(dlgSave.FileName, FileMode.Create);
                file.Write(myFile.BitmatFileData, 0, myFile.BitmatFileData.Length);
                file.Close();
                Console.WriteLine("Bitmap file is saved to " + dlgSave.FileName);
                Thread.Sleep(3000);
                Application.Exit();
            }
        }
    }
}
