using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _3DMAG_v1
{
    class ControlsBlockUnblock
    {
        // Block Interface
        public static void BlockIface(Control[] controls)
        {
            foreach (Control control in controls)
            {
                control.Enabled = false;
            }
        }

        // Unblock Interface
        public static void UnblockIface(Control[] controls)
        {
            foreach (Control control in controls)
            {
                control.Enabled = true;
            }
        }
    }
}
