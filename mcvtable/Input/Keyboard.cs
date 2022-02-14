using mcvtable.Memory;
using System;
using System.Windows.Forms;

namespace mcvtable.Input
{
    class Keyboard
    {
        /// <summary>
        /// Keyboard flags
        /// </summary>
        [Flags]
        public enum KeyboardFlags
        {
            Sprinting = 0x17,
            Forwards = 0x57,
            Left = 0x41,
            Backwards = 0x53,
            Right = 0x44,
        }

        /// <summary>
        /// Send custom keyboard action
        /// </summary>
        public static bool sendActionFocused(KeyboardFlags keyFlag)
        {
            if (MCM.isGameFocused())
            {
                sendAction(keyFlag);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Send custom keyboard action
        /// </summary>
        public static void sendAction(KeyboardFlags keyFlag)
        {
            switch (keyFlag)
            {
                case KeyboardFlags.Forwards:
                    SendKeys.SendWait("W");
                    break;
                case KeyboardFlags.Right:
                    SendKeys.SendWait("A");
                    break;
                case KeyboardFlags.Backwards:
                    SendKeys.SendWait("S");
                    break;
                case KeyboardFlags.Left:
                    SendKeys.SendWait("D");
                    break;
                case KeyboardFlags.Sprinting:
                    if (MCM.GetAsyncKeyState('W'))
                        SendKeys.SendWait("^");
                    break;
            }
        }
    }
}
