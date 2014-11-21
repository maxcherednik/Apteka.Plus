using System;
using System.Windows.Forms;

namespace Apteka.Helpers
{
    public static class GUIThreadInvoker
    {
        public static void InvokeInGUIThread(this Control control, Action action)
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
