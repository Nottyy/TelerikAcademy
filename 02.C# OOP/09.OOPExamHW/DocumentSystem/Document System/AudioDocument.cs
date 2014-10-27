using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentSystems
{
    public class AudioDocument : MultimediaDocuments
    {
        public int SampleRate
        {
            get
            {
                return int.Parse(this.GetProperty("SampleRate").ToString());
            }
            set
            {
                this.LoadProperty("SampleRate", value.ToString());
            }
        }
    }
}
