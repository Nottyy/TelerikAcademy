using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentSystems
{
    public class ExcelDocument : OfficeDocument
    {
        public int NumberOfRows
        {
            get
            {
                return int.Parse(this.GetProperty("rows").ToString());
            }
            set
            {
                this.LoadProperty("rows", value.ToString());
            }
        }
        public int NumberOfColumns
        {
            get
            {
                return int.Parse(this.GetProperty("cols").ToString());
            }
            set
            {
                this.LoadProperty("cols", value.ToString());
            }
        }
    }
}
