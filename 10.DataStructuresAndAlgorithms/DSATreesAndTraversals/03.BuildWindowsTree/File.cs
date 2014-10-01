using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.BuildWindowsTree
{
    public class File
    {
        public File(string fileName, long fileSize)
        {
            this.FileName = fileName;
            this.FileSize = fileSize;
        }

        public long FileSize { get; set; }

        public string FileName { get; set; }
    }
}
