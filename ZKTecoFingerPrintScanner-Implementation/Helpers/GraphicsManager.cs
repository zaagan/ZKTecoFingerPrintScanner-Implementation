using System.Drawing;
using System.Windows.Forms;

namespace ZKTecoFingerPrintScanner_Implementation.Helpers
{
    public class GraphicsManager
    {
        public static void DrawLine(Control frm, Color color, int x, int y, int x1, int y1, int thickness)
        {
            Graphics graphicsObj;
            graphicsObj = frm.CreateGraphics();
            Pen myPen = new Pen(color, thickness);
            graphicsObj.DrawLine(myPen, x, y, x1, y1);
        }
    }
}
