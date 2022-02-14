#region Imports

using System;

using mcvtable;
using mcvtable.Memory;
using mcvtable.SDK;

#endregion

namespace SetPosExample
{
    class Program
    {
        static void Main(string[] _args)
        {
            restart:
            Console.Clear();

            MCVTable.Attach();
            MCVTable.thePlayer.addOffset("PositionX", 0x4B8);

            UIntPtr lpAddr = (UIntPtr)MCM.baseEvaluatePointer(0x4508980, new ulong[] { 0x0, 0x58, 0x138, 0xD0, 0x277, 0x0 });

            string addr = ((ulong)lpAddr).ToString("X");
            string newAddrStr = addr.Remove(addr.Length - 3, 2);
            lpAddr = (UIntPtr)Convert.ToUInt64(newAddrStr, 16); // game wanted to make this unneededly hard :p

            EntityLivingBase lp = new EntityLivingBase(lpAddr);

            Console.WriteLine("Enter position x exc> 100, 64, 503");
            Console.Write("Enter position x> ");

            float[] pos = { 0, 0, 0 };
            try
            {
                string[] args = Console.ReadLine().Replace(" ", "").Split(',');
                pos[0] = float.Parse(args[0]);
                pos[1] = float.Parse(args[1]);
                pos[2] = float.Parse(args[2]);
            }
            catch { goto restart; }

            lp.setPos(pos);
            goto restart;
        }
    }
}
