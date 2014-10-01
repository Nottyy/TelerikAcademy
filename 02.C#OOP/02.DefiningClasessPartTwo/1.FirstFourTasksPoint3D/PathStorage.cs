using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstFourTasksPoint3D
{
    public static class PathStorage
    {
        public static void SavePath(Path path)
        {
            using (StreamWriter writer = new StreamWriter(@"../../savedpaths.txt"))
            {
                foreach (var item in path.Paths)
                {
                    writer.WriteLine(string.Format("({0},{1},{2})", item.X, item.Y, item.Z));
                    writer.Flush();
                }
            }
        }

        internal static Path LoadPath()
        {
            Path loadPath = new Path();
            try
            {
                using (StreamReader reader = new StreamReader(@"../../savedpaths.txt"))
                {
                    while (reader.Peek() >= 0)
                    {
                        String line = reader.ReadLine();
                        String[] splittedLine = line.Split(new char[] { '(', ',', ')' }, StringSplitOptions.RemoveEmptyEntries);
                        loadPath.AddPoint(new Point3D(int.Parse(splittedLine[0]), int.Parse(splittedLine[1]), int.Parse(splittedLine[2])));
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found, try adding a new file");
            }
            catch (IOException io)
            {
                Console.WriteLine(io.Message);
            }
            catch (OutOfMemoryException ome)
            {
                Console.WriteLine(ome.Message);
            }
            finally { }
            return loadPath;
        }
    }
}
