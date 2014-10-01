using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace _04.CreateParameterizedCommand
{
    class CreateParameterizedCommand
    {
        //Write a method that adds a new product in the products table 
        //in the Northwind database. Use a parameterized SQL command.

        static void Main(string[] args)
        {
            InsertProduct("Bilkov Chaiii", 1, true);
        }

        private static void InsertProduct(string productName, int categoryID, bool discontinued)
        {
            SqlConnection dBconnection = new SqlConnection("Server=TOSHIBA-PC;" + "DataBase=northwind;" + "Integrated Security=true");

            dBconnection.Open();

            using (dBconnection)
            {
                SqlCommand command = new SqlCommand("INSERT Products(ProductName, CategoryID, Discontinued)" + 
                    "VALUES(@ProductName, @CategoryID, @Discontinued)",dBconnection);

                command.Parameters.AddWithValue("@ProductName", productName);
                command.Parameters.AddWithValue("@CategoryID", categoryID);
                command.Parameters.AddWithValue("@Discontinued", discontinued);
                command.ExecuteNonQuery();
            }
        }
    }
}
