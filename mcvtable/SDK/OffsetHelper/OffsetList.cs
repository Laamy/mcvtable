using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mcvtable.SDK.OffsetHelper
{
    /// <summary>
    /// Used to Initalize a class with given offsets
    /// </summary>
    public class OffsetList
    {
        /// <summary>
        /// List of offsets the mcvtable'll use
        /// </summary>
        private List<Offset> offsets = new List<Offset>();

        /// <summary>
        /// Give mcvtable an offset
        /// </summary>
        public void addOffset(string name, int offset)
        {
            Offset tmpOffset = new Offset(name, offset);

            offsets.Add(tmpOffset);
        }

        /// <summary>
        /// Get offset by name
        /// </summary>
        public Offset getOffset(string name)
        {
            Offset tmpOffset = Offset.Empty;

            foreach (Offset v in offsets)
            {
                if (v.Name == name)
                    tmpOffset = v;
            }

            return tmpOffset;
        }

        /// <summary>
        /// Remove offset from mcvtable
        /// </summary>
        public Boolean removeOffset(string name)
        {
            Boolean tmpOffset = false;

            foreach (Offset v in offsets)
            {
                if (v.Name == name)
                    offsets.Remove(v);
            }

            return tmpOffset;
        }

        /// <summary>
        /// Remove all offsets from mcvtable
        /// </summary>
        public void clear() => offsets.Clear();
    }
}
