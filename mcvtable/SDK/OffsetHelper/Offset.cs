using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mcvtable.SDK.OffsetHelper
{
    /// <summary>
    /// Offset data
    /// </summary>
    public struct Offset
    {
        /// <summary>
        /// VTable address inside of a class
        /// </summary>
        public static Offset VTable = new Offset("VTable", 0x0);

        /// <summary>
        /// Empty VTable
        /// </summary>
        public static Offset Empty = new Offset("", 0x0);

        /// <summary>
        /// Initalize a new offset with a name & offset
        /// </summary>
        /// <param name="name"></param>
        /// <param name="offset"></param>
        public Offset(string name, int offset)
        {
            this.name = name;
            this.offset = offset;
        }

        private string name;
        private int offset;

        /// <summary>
        /// Offset name
        /// </summary>
        public string Name
        { get => name; }

        /// <summary>
        /// Offset
        /// </summary>
        public int OffsetAddr
        { get => offset; }

        /// <summary>
        /// Offset
        /// </summary>
        public Boolean isEmpty
        {
            get
            {
                Boolean output = true;

                if (Name.Length > 0)
                    output = false;

                if (OffsetAddr > 0)
                    output = false;

                return output;
            }
        }
    }
}
