using System.Drawing;
using System.Windows.Forms;

namespace ZKTecoFingerPrintScanner_Implementation.Controls
{
    public partial class StatusBar : UserControl
    {

        public Color StatusBarForeColor
        {
            get { return lblMessage.ForeColor; }
            set { lblMessage.ForeColor = value; }
        }

        public Color StatusBarBackColor
        {
            get { return lblMessage.BackColor; }
            set { lblMessage.BackColor = value; }
        }


        bool messageType;

        public bool MessageType
        {
            get { return messageType; }
            set { messageType = value; }
        }
        public string Message
        {
            get { return  lblMessage.Text; }
            set { lblMessage.Text = value; }
        }

        public StatusBar()
        {
            InitializeComponent();
          
        }
    }
}
