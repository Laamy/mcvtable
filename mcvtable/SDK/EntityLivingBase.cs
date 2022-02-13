using mcvtable.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mcvtable.SDK
{
    /// <summary>
    /// Main living entity class
    /// </summary>
    public class EntityLivingBase : Actor
    {
        /// <summary>
        /// Initialize Actor class at uintptr_t (UIntPtr)
        /// </summary>
        /// <param name="address"></param>
        public EntityLivingBase(UIntPtr address) : base(address) {}

        /// <summary>
        /// Initalize class at ulong (ULong 2 UIntPtr)
        /// </summary>
        /// <param name="address"></param>
        public EntityLivingBase(ulong address) : base((UIntPtr)address) {}

        /// <summary>
        /// Initalize class at long (Long 2 UIntPtr)
        /// </summary>
        /// <param name="address"></param>
        public EntityLivingBase(long address) : base((UIntPtr)address) {}

        /// <summary>
        /// Set your player position
        /// </summary>
        public void setPos(int[] pos)
        {
            int offset = MCVTable.thePlayer.getOffset("PositionX").OffsetAddr;
            UIntPtr AABBAddress = address + offset;

            MCM.writeFloat((ulong)AABBAddress + 0x0 , pos[0]);
            MCM.writeFloat((ulong)AABBAddress + 0x4 , pos[1]);
            MCM.writeFloat((ulong)AABBAddress + 0x8 , pos[2]);

            MCM.writeFloat((ulong)AABBAddress + 0xC , pos[0] + 0.6f);
            MCM.writeFloat((ulong)AABBAddress + 0x10, pos[1] + 1.8f);
            MCM.writeFloat((ulong)AABBAddress + 0x14, pos[2] + 0.6f);
        }

        /// <summary>
        /// Set your player position
        /// </summary>
        public float[] getPos()
        {
            int offset = MCVTable.thePlayer.getOffset("PositionX").OffsetAddr;
            UIntPtr AABBAddress = address + offset;

            float[] pos = new float[] { 0, 0, 0 };

            pos[0] = MCM.readFloat((ulong)AABBAddress + 0x0);
            pos[1] = MCM.readFloat((ulong)AABBAddress + 0x4);
            pos[2] = MCM.readFloat((ulong)AABBAddress + 0x8);

            return pos;
        }
    }
}
