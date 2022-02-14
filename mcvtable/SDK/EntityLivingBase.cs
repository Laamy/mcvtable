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
        ///  (Requirements: thePlayer.PositionX)
        /// </summary>
        public void setPos(float[] pos)
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
        /// get your player position
        ///  (Requirements: thePlayer.PositionX)
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

        /// <summary>
        /// get your player old position
        ///  (Requirements: thePlayer.PositionX)
        /// </summary>
        public float[] getOldPos()
        {
            int offset = MCVTable.thePlayer.getOffset("PositionX").OffsetAddr;
            UIntPtr AABBAddress = address + offset;

            float[] pos = new float[] { 0, 0, 0 };

            pos[0] = MCM.readFloat((ulong)AABBAddress + 0xC);
            pos[1] = MCM.readFloat((ulong)AABBAddress + 0x14);
            pos[2] = MCM.readFloat((ulong)AABBAddress + 0x10);

            return pos;
        }

        /// <summary>
        /// Set your player directional rotations
        ///  (Requirements: thePlayer.CameraYaw)
        /// </summary>
        public void setRots(float[] rots)
        {
            int offset = MCVTable.thePlayer.getOffset("CameraYaw").OffsetAddr;
            UIntPtr RotsAddress = address + offset;

            MCM.writeFloat((ulong)RotsAddress + 0x0, rots[0]);
            MCM.writeFloat((ulong)RotsAddress + 0x4, rots[1]);
        }

        /// <summary>
        /// get your player runtime id
        ///  (Requirements: thePlayer.RuntimeID)
        /// </summary>
        public UIntPtr getRuntimeID()
        {
            int offset = MCVTable.thePlayer.getOffset("RuntimeID").OffsetAddr;
            UIntPtr AABBAddress = address + offset;

            UIntPtr ID = (UIntPtr)0;

            ID = (UIntPtr)MCM.readInt64((ulong)AABBAddress);

            return ID;
        }

        /// <summary>
        /// get your player rotations
        ///  (Requirements: thePlayer.CameraYaw)
        /// </summary>
        public float[] getRots()
        {
            int offset = MCVTable.thePlayer.getOffset("CameraYaw").OffsetAddr;
            UIntPtr RotsAddress = address + offset;

            float[] rots = new float[] { 0, 0 };

            rots[0] = MCM.readFloat((ulong)RotsAddress + 0x0);
            rots[1] = MCM.readFloat((ulong)RotsAddress + 0x4);

            return rots;
        }

        /// <summary>
        /// get your player prev rotations
        ///  (Requirements: thePlayer.CameraYaw)
        /// </summary>
        public float[] getPrevRots()
        {
            int offset = MCVTable.thePlayer.getOffset("CameraYaw").OffsetAddr;
            UIntPtr RotsAddress = address + offset;

            float[] rots = new float[] { 0, 0 };

            rots[0] = MCM.readFloat((ulong)RotsAddress + 0x8);
            rots[1] = MCM.readFloat((ulong)RotsAddress + 0xC);

            return rots;
        }
    }
}
