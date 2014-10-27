using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace _02.GetNameAndDescriptionFromCategories
{
    class GetNameAndDescriptionFromCategories
    {
        static void Main(string[] args)
        {
            SqlConnection dBconnection = new SqlConnection("Server=TOSHIBA-PC;" + "DataBase=northwind;" + "Integrated Security=true");
            dBconnection.Open();

            using(dBconnection)
            {
                SqlCommand command = new SqlCommand("SELECT CategoryName, Description FROM Categories", dBconnection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string categoryName = (string)reader["CategoryName"];
                    string description = (string)reader["Description"];
                    Console.WriteLine("Category Name -> {0}, Descriotion -> {1}",categoryName, description);
                    Console.WriteLine();
                }
            }
        }
    }
}
