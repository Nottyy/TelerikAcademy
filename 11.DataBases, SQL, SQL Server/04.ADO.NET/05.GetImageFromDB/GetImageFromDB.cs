﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;

namespace _05.GetImageFromDB
{
    class GetImageFromDB
    {
        const string FILE_LOCATION = @"..\";
        const string FILE_EXTENSION = @".jpg";

        static void Main()
        {
            //After executing program you can find the picture files in the bin directory of the project,
            //make sure that the folder is empty before executing.
            ExtractImageFromDB();
        }

        static void ExtractImageFromDB()
        {
            SqlConnection dbConn = new SqlConnection("Server=TOSHIBA-PC; " +
            "Database=northwind; Integrated Security=true");

            dbConn.Open();

            using (dbConn)
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT Picture, CategoryID, CategoryName FROM Categories", dbConn);

                SqlDataReader reader = cmd.ExecuteReader();

                using (reader)
                {
                    byte[] image;
                    int categoryId;
                    string categoryName;
                    while (reader.Read())
                    {
                        image = (byte[])reader["Picture"];
                        categoryId = (int)reader["CategoryID"];
                        categoryName = (string)reader["CategoryName"];
                        WriteBinaryFile(image, FILE_LOCATION + categoryId + FILE_EXTENSION);
                        image = null;
                    }
                }
            }
        }

        static void WriteBinaryFile(byte[] fileContents, string fileLocation)
        {
            FileStream stream = new FileStream(fileLocation, FileMode.Create);
            using (stream)
            {
                stream.Write(fileContents, 0, fileContents.Length);
            }
        }

    }
}
