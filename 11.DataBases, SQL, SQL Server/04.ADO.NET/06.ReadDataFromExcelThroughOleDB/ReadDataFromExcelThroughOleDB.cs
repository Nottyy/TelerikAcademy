using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace _06.ReadDataFromExcelThroughOleDB
{
    //Create an Excel file with 2 columns: name and score:
    //Write a program that reads your MS Excel file through the OLE DB data provider
    //and displays the name and score row by row.

    class ReadDataFromExcelThroughOleDB
    {
        static void Main(string[] args)
        {
            OleDbConnection oleDbCon = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;" +
            @"Data Source=..\..\tableXL.xlsx;Extended Properties=""Excel 12.0 XML;HDR=Yes""");
            oleDbCon.Open();

            using(oleDbCon)
            {
                OleDbCommand oleCommand = new OleDbCommand("SELECT * FROM [Sheet1$]", oleDbCon);
                OleDbDataReader reader = oleCommand.ExecuteReader();

                while (reader.Read())
                {
                    string name = (string)reader["Name"];
                    double score = (double)reader["Score"];
                    Console.WriteLine("Name -> {0}, Score -> {1}", name, score);
                }
            }
        }
    }
}
