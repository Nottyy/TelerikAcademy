using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentSystems
{
    public class TextDocument : Document, IEditable
    {
        public string Charset
        {
            get
            {
                return (this.GetProperty("chars").ToString());
            }
            set
            {
                this.LoadProperty("SampleRate", value.ToString());
            }
        }

        public void ChangeContent(string newContent)
        {
            this.Content = newContent;
        }
    }
}
