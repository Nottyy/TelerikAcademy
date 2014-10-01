
namespace FirstFourTasksPoint3D
{
    public struct Point3D
    {
        private static readonly Point3D startCoor = new Point3D(0, 0, 0);

        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Point3D(int x, int y, int z)
            : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public override string ToString()
        {
            return string.Format("X: {0}, Y: {1}, Z: {2}", X, Y, Z);
        }

        public static Point3D ReturnZeroCoord
        {
            get
            {
                return startCoor;
            }
        }
    }
}
