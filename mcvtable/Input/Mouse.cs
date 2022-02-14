using mcvtable.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace mcvtable.Input
{
    class Mouse
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(long dwFlags, long dx, long dy, long cButtons, long dwExtraInfo);

        [Flags]
        public enum MouseFlags
        {
            Hit = 0x02,
            Place = 0x08,
            CopyBlock = 0x20,
        }

        public static bool sendActionFocused(MouseFlags keyFlag)
        {
            if (MCM.isGameFocused())
            {
                sendAction(keyFlag);
                return true;
            }
            return false;
        }

        public static void sendAction(MouseFlags keyFlag)
        {
            switch (keyFlag)
            {
                case MouseFlags.Hit:
                    mouse_event(0x02, 0, 0, 0, 0);
                    mouse_event(0x04, 0, 0, 0, 0);
                    break;
                case MouseFlags.Place:
                    mouse_event(0x08, 0, 0, 0, 0);
                    mouse_event(0x10, 0, 0, 0, 0);
                    break;
                case MouseFlags.CopyBlock:
                    mouse_event(0x20, 0, 0, 0, 0);
                    mouse_event(0x40, 0, 0, 0, 0);
                    break;
                default:
                    throw new Exception("Invalid MouseFlags");
            }
        }
    }
}
