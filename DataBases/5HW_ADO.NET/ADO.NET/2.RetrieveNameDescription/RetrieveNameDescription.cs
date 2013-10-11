namespace _2.RetrieveNameDescription
{
    using System;
    using System.Linq;
    using System.Data.SqlClient;

    public class RetrieveNameDescription
    {
        static void Main()
        {
            SqlConnection dbConnection = new SqlConnection("Server=.\\SQLEXPRESS; " +
                                                    "Database=Northwind; Integrated Security=true");
            dbConnection.Open();
            using (dbConnection)
            {
                SqlCommand cmdAllRows = new SqlCommand("SELECT CategoryName, Description FROM Categories", dbConnection);
                SqlDataReader reader = cmdAllRows.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string categoryName = (string)reader["CategoryName"];
                        string description = (string)reader["Description"];
                        Console.WriteLine("{0}: {1}", categoryName, description);
                    }
                }
            }
        }
    }
}