namespace _6.ReadFromExcel
{
    using System;
    using System.Linq;
    using System.Data.OleDb;
    using System.Data;

    public class ReadFromExcel
    {
        public static void Main()
        {
            DataTable dt = new DataTable("newtable");
            OleDbConnectionStringBuilder csbuilder = new OleDbConnectionStringBuilder();
            csbuilder.Provider = "Microsoft.ACE.OLEDB.12.0";
            csbuilder.DataSource = @"..\..\Excel.xlsx";
            csbuilder.Add("Extended Properties", "Excel 12.0 Xml;HDR=YES");

            using (OleDbConnection connection = new OleDbConnection(csbuilder.ConnectionString))
            {
                connection.Open();
                string selectSql = @"SELECT * FROM [Sheet1$]";
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(selectSql, connection))
                {
                    adapter.FillSchema(dt, SchemaType.Source);
                    adapter.Fill(dt);
                }
            }

            foreach (DataRow row in dt.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    Console.Write(item+ " ");
                }
                Console.WriteLine();
            }
        }
    }
}