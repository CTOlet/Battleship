using System.Windows.Forms;

namespace Client
{
    partial class BufferedPanel : Panel
    {
        public BufferedPanel()
        {
            DoubleBuffered = true;
        }
    }
}
