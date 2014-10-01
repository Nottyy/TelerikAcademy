using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace _07.InsertParametersIntoExcelTable
{
    //Implement appending new rows to the Excel file.

    class InsertParametersIntoExcelTable
    {
        static void Main(string[] args)
        {
            OleDbConnection oleDbCon = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;" +
            @"Data Source=..\..\tableXL.xlsx;Extended Properties=""Excel 12.0 XML;HDR=Yes""");
            string[] players = new string[5] { "Stamen", "Ivan", "Gosho", "Elvis", "Nikodim" };

            for (int i = 0; i < players.Length; i++)
            {
                InsertParameters(players[i], i * 5, oleDbCon);
            }
        }


        static private void InsertParameters(string name, double score, OleDbConnection oleDbConnection)
        {
            OleDbCommand oleCommand = new OleDbCommand("INSERT INTO [Sheet1$] (Name, Score) VALUES(@Name, @Score)", oleDbConnection);
            oleDbConnection.Open();

            oleCommand.Parameters.AddWithValue("@Name", name);
            oleCommand.Parameters.AddWithValue("@Score", score);
            oleCommand.ExecuteNonQuery();

            oleDbConnection.Close();
        }
    }
}
