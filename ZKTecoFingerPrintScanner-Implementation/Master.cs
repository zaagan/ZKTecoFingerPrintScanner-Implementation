using Dofe_Re_Entry.UserControls.DeviceController;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ZKTecoFingerPrintScanner_Implementation.Helpers;

namespace ZKTecoFingerPrintScanner_Implementation
{
    public partial class Master : Form
    {
        FingerPrintControl fingerPrintControl = null;
        public Master()
        {
            InitializeComponent();
            pnlStage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            LoadFingerprintControl();

        }


        
        /// <summary>
        /// Before closing the application clear all the resources used by the application
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            try
            {
                
                if (fingerPrintControl != null)
                {
                    if (fingerPrintControl.cmbIdx.Items.Count > 0)
                        fingerPrintControl.OnDisconnect();
                }
            }
            catch
            { }
        }

        private void LoadFingerprintControl()
        {
            fingerPrintControl = new FingerPrintControl();
            fingerPrintControl.parentForm = this;
            fingerPrintControl.Dock = DockStyle.Fill;
            pnlStage.Controls.Add(fingerPrintControl);
        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            int y = panel2.Height;
            GraphicsManager.DrawLine(panel2, Color.LightGray, 0, y, panel2.Width, y, 2);
        }
    }
}
