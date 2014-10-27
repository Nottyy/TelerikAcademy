namespace DatabaseCloning
{
    using System;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Configuration;

    using NorthwindModel;

    public class DatabaseCloning
    {
        static void Main()
        {
            (new NorthwindEntities()).Database.CreateIfNotExists();
        }
    }
}
