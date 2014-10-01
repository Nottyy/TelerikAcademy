using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace _03.JoinTablesCategoriesAndProducts
{
    class JoinTablesCategoriesAndProducts
    {
        static void Main(string[] args)
        {
            SqlConnection dBconnection = new SqlConnection("Server=TOSHIBA-PC;" + "DataBase=northwind;" + "Integrated Security=true");
            dBconnection.Open();

            using (dBconnection)
            {
                SqlCommand command = new SqlCommand("SELECT c.CategoryName, p.ProductName FROM Categories c JOIN Products p ON c.CategoryID = p.CategoryID ORDER BY c.CategoryName",dBconnection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string categoryName = (string)reader["CategoryName"];
                    string productName = (string)reader["ProductName"];
                    Console.WriteLine("Category Name -> {0}, Product Name -> {1}", categoryName, productName);
                    Console.WriteLine();
                }
            }
        }
    }
}
