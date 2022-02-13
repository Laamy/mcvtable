﻿using mcvtable.Memory;
using mcvtable.SDK.OffsetHelper;

namespace mcvtable
{
    /// <summary>
    /// Static class you place offsets inside of
    /// </summary>
    public class MCVTable
    {
        public static OffsetList thePlayer = new OffsetList();

        /// <summary>
        /// Attach mcvtable to minecraft
        /// </summary>
        public static void Attach()
        {
            MCM.openWindowHost("ApplicationFrameHost", "Minecraft");
            MCM.openGame("Minecraft.Windows");
        }
    }
}
