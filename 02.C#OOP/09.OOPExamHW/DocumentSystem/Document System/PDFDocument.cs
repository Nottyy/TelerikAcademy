using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentSystems
{
    public class PDFDocument : EncryptableDocument
    {
        public int NumberOfPages
        {
            get
            {
                return int.Parse(this.GetProperty("pages").ToString());
            }
            set
            {
                this.LoadProperty("pages", value.ToString());
            }
        }
    }
}
