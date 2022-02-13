using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mcvtable.SDK
{
    /// <summary>
    /// The main class SDKObj's inherit
    /// </summary>
    public class Actor
    {
        /// <summary>
        /// Class memory address
        /// </summary>
        public UIntPtr address;

        /// <summary>
        /// Initialize Actor class at uintptr_t (UIntPtr)
        /// </summary>
        /// <param name="address"></param>
        public Actor(UIntPtr address) => this.address = address;

        /// <summary>
        /// Initalize class at ulong (ULong 2 UIntPtr)
        /// </summary>
        /// <param name="address"></param>
        public Actor(ulong address) => this.address = (UIntPtr)address;

        /// <summary>
        /// Initalize class at long (Long 2 UIntPtr)
        /// </summary>
        /// <param name="address"></param>
        public Actor(long address) => this.address = (UIntPtr)address;
    }
}
