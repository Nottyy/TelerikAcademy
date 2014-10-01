using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentSystems
{
    public class WordDocument : OfficeDocument, IEditable
    {
        public ulong NumberOfCharacters
        {
            get
            {
                return ulong.Parse(this.GetProperty("chars").ToString());
            }
            set
            {
                this.LoadProperty("chars", value.ToString());
            }
        }

        public void ChangeContent(string newContent)
        {
            this.Content = newContent;
        }
    }
}
