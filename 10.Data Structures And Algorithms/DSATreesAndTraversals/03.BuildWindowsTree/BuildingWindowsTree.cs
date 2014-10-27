using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.BuildWindowsTree
{
    public class BuildingWindowsTree
    {
        static void Main()
        {
            // Test it with simple directory, because testing with the Windows directory is very slow
            string directory = @"E:\My Space\MySpace\Movies";
            Folder rootFolder = new Folder(directory);
            MakeTree(rootFolder);
            //PrintTree(rootFolder, ""); // Uncomment to view the result on the console!
            
            var sum = CalculateSumOfSubTreeElementsSizes(rootFolder, 1, 0);
            Console.WriteLine("The sum of the subtree is: {0}", sum);
        }

        public static void PrintTree(Folder root, string spaces)
        {
            Console.WriteLine(spaces + root.FolderName);
            foreach (var folder in root.ChildFolders)
            {
                PrintTree(folder, spaces + " ");
            }

            foreach (var file in root.Files)
            {
                Console.WriteLine(spaces + " " + file.FileName + " " + file.FileSize);
            }
        }

        private static long CalculateSumOfSubTreeElementsSizes(Folder rootFolder, int depth, long sum)
        {
            foreach (var file in rootFolder.Files)
            {
                sum += file.FileSize;
            }

            if (depth == 0)
            {
                return sum;
            }
            else
            {
                if (rootFolder.ChildFolders.Count > 0)
                {
                    foreach (var folder in rootFolder.ChildFolders)
                    {
                        sum += CalculateSumOfSubTreeElementsSizes(folder, depth - 1, sum);
                    }
                }

                return sum;
            }
        }

        private static void MakeTree(Folder root)
        {
            IEnumerable<string> folders = Directory.EnumerateDirectories(root.FolderName);
            IEnumerable<string> files = Directory.GetFiles(root.FolderName);

            AddFilesToDiretory(root, files);
            AddFoldersToDirectory(root, folders);

            for (int i = 0; i < root.ChildFolders.Count; i++)
            {
                try
                {
                    Folder currentChildFolder = root.ChildFolders[i];
                    MakeTree(currentChildFolder);
                }
                catch (UnauthorizedAccessException)
                {
                    continue;
                }
            }
        }

        private static void AddFoldersToDirectory(Folder rootFolder, IEnumerable<string> folders)
        {
            List<Folder> allFoldersInTheRootFolder = new List<Folder>();
            foreach (var folder in folders)
            {
                Folder currentFolder = new Folder(folder.ToString());
                allFoldersInTheRootFolder.Add(currentFolder);
            }

            rootFolder.ChildFolders = allFoldersInTheRootFolder;
        }

        private static void AddFilesToDiretory(Folder rootFolder, IEnumerable<string> files)
        {
            List<File> allFilesInTheRootFolder = new List<File>();

            foreach (var file in files)
            {
                FileInfo currentFileInfo = new FileInfo(file);
                long currentFileSize = currentFileInfo.Length;

                File currentFile = new File(file.ToString(), currentFileSize);
                allFilesInTheRootFolder.Add(currentFile);
            }

            rootFolder.Files = allFilesInTheRootFolder;
        }
    }
}
