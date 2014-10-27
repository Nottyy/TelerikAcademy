using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentSystems
{
    public abstract class MultimediaDocuments : BinaryDocument
    {
        public int Length 
        {
            get
            {
                return int.Parse(this.GetProperty("Length").ToString());
            }
            set
            {
                this.LoadProperty("Length", value.ToString());
            }
        }
    }
}
