namespace RefactoringCohesionAndCoupling
{
    using System;

    public class UtilsTest
    {
        static void Main()
        {
            try
            {
                Console.WriteLine(UtilsWorkingWithFiles.GetFileExtension("example"));
                Console.WriteLine(UtilsWorkingWithFiles.GetFileExtension("example.pdf"));
                Console.WriteLine(UtilsWorkingWithFiles.GetFileExtension("example.new.pdf"));

                Console.WriteLine(UtilsWorkingWithFiles.GetFileNameWithoutExtension("example"));
                Console.WriteLine(UtilsWorkingWithFiles.GetFileNameWithoutExtension("example.pdf"));
                Console.WriteLine(UtilsWorkingWithFiles.GetFileNameWithoutExtension("example.new.pdf"));
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine(ane.Message);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }

            Console.WriteLine("Distance in the 2D space = {0:f2}", UtilsGeometry.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}", UtilsGeometry.CalcDistance3D(5, 2, -1, 3, -6, 4));

            UtilsCuboid cube = new UtilsCuboid(3, 4, 5);
            Console.WriteLine("Volume = {0:f2}", cube.CalcVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", cube.CalcDiagonalXYZ());
            Console.WriteLine("Diagonal XY = {0:f2}", cube.CalcDiagonalXY());
            Console.WriteLine("Diagonal XZ = {0:f2}", cube.CalcDiagonalXZ());
            Console.WriteLine("Diagonal YZ = {0:f2}", cube.CalcDiagonalYZ());
        }
    }
}