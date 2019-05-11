using libzkfpcsharp;    // <--- Implement the namespace
using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace YourProject
{
    public class YourClassName
    {

        // PARAMETER CODES
        const int PARAM_CODE_IMAGE_WIDTH = 1;
        const int PARAM_CODE_IMAGE_HEIGHT = 2;
        const int PARAM_CODE_IMAGE_DPI = 3;
        const int PARAM_CODE_IMAGE_DATA_SIZE = 106;

        zkfp fpInstance = new zkfp();  // <--- Create an instance 

        public void InitializeDevice()
        {

            int callBackCode = fpInstance.Initialize();
            if (zkfp.ZKFP_ERR_OK == callBackCode)
            {
                int nCount = fpInstance.GetDeviceCount();
                if (nCount > 0)
                {
                    for (int index = 1; index <= nCount; index++)
                    {
                        // Hold these indexes somewere
                        // It represents the index of the device you wish to connect to 
                    }
                    // Connected Successfully
                }
            }
            else {  /* Unable to initialize, Clear previous resources */ }
        }


        int RegisterCount = 0;
        int regTempLen = 0;
        int iFid = 1;
        const int REGISTER_FINGER_COUNT = 3;
        byte[][] RegTmps = new byte[REGISTER_FINGER_COUNT][];
        byte[] FPBuffer;   // Image Buffer
        Thread captureThread = null; // <--- Scan time to time for any new fingerprints 
        int mfpWidth = 0, mfpHeight = 0; // <--- Holds the width and height of the fingerprint images
        bool bIsTimeToDie = false;


        public void ConnectDevice(int deviceIndex)
        {
            int openDeviceCallBackCode = fpInstance.OpenDevice(deviceIndex);

            if (zkfp.ZKFP_ERR_OK != openDeviceCallBackCode)
            {
                // Unable to connect with the device
                return;
            }

            RegisterCount = 0;
            regTempLen = 0;
            iFid = 1;

            for (int i = 0; i < REGISTER_FINGER_COUNT; i++)
            {
                RegTmps[i] = new byte[2048];
            }

            byte[] paramValue = new byte[4];


            // Retrieve the width of the fingerprint image
            int size = 4;
            fpInstance.GetParameters(PARAM_CODE_IMAGE_WIDTH, paramValue, ref size);
            zkfp2.ByteArray2Int(paramValue, ref mfpWidth);

            // Retrieve the height of the fingerprint image
            size = 4;
            fpInstance.GetParameters(PARAM_CODE_IMAGE_HEIGHT, paramValue, ref size);
            zkfp2.ByteArray2Int(paramValue, ref mfpHeight);


            FPBuffer = new byte[mfpWidth * mfpHeight];
            //FPBuffer = new byte[fpInstance.imageWidth * fpInstance.imageHeight];

            // Create a thread to retrieve any new fingerprint and handle device events
            captureThread = new Thread(new ThreadStart(DoCapture));
            captureThread.IsBackground = true;
            captureThread.Start();

            bIsTimeToDie = false;

        }

        const int MESSAGE_CAPTURED_OK = 0x0400 + 6;
        byte[] CapTmp = new byte[2048];
        int cbCapTmp = 2048;
        IntPtr FormHandle = IntPtr.Zero; // To hold the handle of the form
        private void DoCapture()
        {
            try
            {
                while (!bIsTimeToDie)
                {
                    cbCapTmp = 2048;
                    int ret = fpInstance.AcquireFingerprint(FPBuffer, CapTmp, ref cbCapTmp);

                    if (ret == zkfp.ZKFP_ERR_OK)
                    {
                        SendMessage(FormHandle, MESSAGE_CAPTURED_OK, IntPtr.Zero, IntPtr.Zero);
                    }
                    Thread.Sleep(100);
                }
            }
            catch { }
        }


        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);


    }




}