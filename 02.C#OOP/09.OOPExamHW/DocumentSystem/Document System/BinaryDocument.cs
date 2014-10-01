using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentSystems
{
    public abstract class BinaryDocument : Document
    {
        public ulong Size
        {
            get
            {
                return ulong.Parse(this.GetProperty("Size").ToString());
            }
            set
            {
                this.LoadProperty("SampleRate", value.ToString());
            }
        }
    }
}
