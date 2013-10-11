namespace _7.AddRowsToExcel
{
    using System;
    using System.Data;
    using System.Data.OleDb;
    using System.Linq;

    public class AddRowsToTable
    {
        static void Main()
        {
            Console.WriteLine("Rows afected: {0}", InsertToTable("S.Rusev", 21));
        }

        static int InsertToTable(string name, int score)
        {
            int rowsAdded = 0;
            OleDbConnectionStringBuilder csbuilder = new OleDbConnectionStringBuilder();
            csbuilder.Provider = "Microsoft.ACE.OLEDB.12.0";
            csbuilder.DataSource = @"..\..\Excel.xlsx";
            csbuilder.Add("Extended Properties", "Excel 12.0 Xml;HDR=YES");

            using (OleDbConnection connection = new OleDbConnection(csbuilder.ConnectionString))
            {
                string insertToTable = @"INSERT INTO [Sheet1$] (Name, Score) VALUES (@Name, @Score);";
                using (OleDbCommand command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandType = CommandType.Text;
                    command.CommandText = insertToTable;
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Score", score);
                    for (int i = 0; i < 20; i++)
                    {
                        rowsAdded += command.ExecuteNonQuery();    
                    }
                }
            }

            return rowsAdded;
        }
    }
}