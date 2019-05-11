using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ZKTecoFingerPrintScanner_Implementation.Helpers
{
    public class Utilities
    {
        public static void EnableControls(bool enableControl, params Control[] controls)
        {
            foreach (var control in controls)
            {
                control.Enabled = enableControl;
            }
        }

        public static Bitmap GetImage(byte[] buffer, int width, int height)
        {
            Bitmap output = new Bitmap(width, height);
            Rectangle rect = new Rectangle(0, 0, width, height);
            BitmapData bmpData = output.LockBits(rect, ImageLockMode.ReadWrite, output.PixelFormat);
            IntPtr ptr = bmpData.Scan0;

            Marshal.Copy(buffer, 0, ptr, buffer.Length);
            output.UnlockBits(bmpData);

            return output;
        }


        public static void ShowStatusBar(string message, Controls.StatusBar statusBar, bool type)
        {
            statusBar.Visible = true;
            statusBar.Message = message;
            statusBar.StatusBarForeColor = Color.White;
            if (type)
                statusBar.StatusBarBackColor = Color.FromArgb(79, 208, 154);
            else
                statusBar.StatusBarBackColor = Color.FromArgb(230, 112, 134);

        }



    }
}
