using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace _01.GetNumberOfRowsInCategoriesTable
{
    class Program
    {
        //Write a program that retrieves from the Northwind sample database in 
        //MS SQL Server the number of  rows in the Categories table.

        static void Main(string[] args)
        {
            SqlConnection dBconnection = new SqlConnection("Server=TOSHIBA-PC;" + "Database=northwind;" + "Integrated Security=true");
            dBconnection.Open();

            using(dBconnection)
            {
                SqlCommand command = new SqlCommand("SELECT COUNT(CategoryID) FROM Categories", dBconnection);
                int count = (int)command.ExecuteScalar();
                Console.WriteLine("The number of  rows in the Categories table is -> {0}", count);
            }
        }
    }
}
