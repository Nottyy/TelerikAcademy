using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.BuildWindowsTree
{
    public class Folder
    {
        public Folder(string folderName)
        {
            if (string.IsNullOrEmpty(folderName))
            {
                throw new ArgumentException("Invalid folder name!");
            }

            this.FolderName = folderName;
            this.Files = new List<File>();
            this.ChildFolders = new List<Folder>();
        }

        public Folder(string folderName,List<File> files)
            : this(folderName)
        {
            this.Files = files;
            this.ChildFolders = new List<Folder>();
        }

        public Folder(string folderName, List<File> files, List<Folder> childFolders)
            : this(folderName, files)
        {
            this.ChildFolders = childFolders;
        }

        public string FolderName { get; set; }

        public List<File> Files { get; set; }

        public List<Folder> ChildFolders { get; set; }
    }
}
