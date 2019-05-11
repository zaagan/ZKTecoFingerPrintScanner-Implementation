namespace ZKTecoFingerPrintScanner_Implementation.Helpers
{
    public class FingerPrintDeviceUtilities
    {
        public static string DisplayDeviceErrorByCode(int errCode)
        {
            string message = string.Empty;
            switch (errCode)
            {
                case -25: message = "The device is already connected"; break;

                case -24: message = "The device is not initialized"; break;

                case -23: message = "The device is not started"; break;

                case -22: message = "Failed to combine the registered fingerprint templates."; break;

                case -20: message = "Fingeprint comparison failed"; break;

                case -18: message = "Capture cancelled"; break;

                case -17: message = "Operation failed"; break;

                case -14: message = "Failed to delete the fingerprint template"; break;

                case -13: message = "Failed to add the fingerprint template"; break;

                case -12: message = "The fingerprint is being captured"; break;

                case -11: message = "Insufficient memory"; break;

                case -10: message = "Aborted"; break;

                case -9: message = "Failed to extract the fingerprint template"; break;

                case -8: message = "Failed to capture the image"; break;

                case -7: message = "Invalid Handle"; break;

                case -6: message = "Failed to start the device"; break;

                case -5: message = "Invalid parameter"; break;

                case -4: message = "Not supported by the interface"; break;

                case -3: message = "No device connected"; break;

                case -2: message = "Failed to initalize the capture library"; break;

                case -1: message = "Failed to initialize the algorithm library"; break;

                case 0: message = "Operation succeeded"; break;

                case 1: message = "Initalized"; break;

                default: message = "Unknown operation"; break;
            }

            return message;
        }
    }
}
