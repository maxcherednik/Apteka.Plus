using System;
using System.Windows.Forms;

namespace Apteka.Helpers
{
    public static class GuiThreadInvoker
    {
        public static void InvokeInGuiThread(this Control control, Action action)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(action);
            }
            else
            {
                action();
            }
        }
    }
}
