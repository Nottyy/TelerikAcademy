using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace _08.FindAllProductsContainingGivenSubstring
{
    //Write a program that reads a string from the console and 
    //finds all products that contain this string. 
    //Ensure you handle correctly characters like ', %, ", \ and _.

    class FindAllProductsContainingGivenSubstring
    {
        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection("Server=TOSHIBA-PC;" + "Database=northwind;" + "Integrated Security=true");
            

            Console.WriteLine("Enter substring: ");
            string input = Console.ReadLine();
            string[] inputSeparators = input.Split(new char[] { '%', '_', '\\','\'', '\"','=' });
            if (inputSeparators.Length > 1)
            {
                Console.WriteLine("SQL Injection!?");
            }
            else
            {
                FindProduct(input, con);
            }
        }

        static private void FindProduct(string substring, SqlConnection con)
        {
            con.Open();

            using (con)
            {
                SqlCommand command = new SqlCommand("SELECT ProductName FROM Products WHERE ProductName LIKE @Substring",con);
                command.Parameters.AddWithValue("@Substring", "%" + substring + "%");
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string productName = (string)reader["ProductName"];
                    Console.WriteLine("ProductName ---> {0}",productName);
                }
            }
        }
    }
}
