using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentSystems
{
    public class VideoDocument : MultimediaDocuments
    {
        public int FrameRate 
        {
            get
            {
                return int.Parse(this.GetProperty("framerate").ToString());
            }
            set
            {
                this.LoadProperty("framerate", value.ToString());
            }
        }
    }
}
