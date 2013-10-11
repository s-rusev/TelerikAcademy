namespace _3.ProductsNamesCategories
{
    using System;
    using System.Data.SqlClient;

    public class ProductsNamesCategories
    {
        static void Main()
        {
            SqlConnection dbConnection = new SqlConnection("Server=.\\SQLEXPRESS; " +
                                                    "Database=Northwind; Integrated Security=true");
            dbConnection.Open();
            using (dbConnection)
            {
                string sql = "SELECT CategoryName, ProductName FROM Products" +
                             " JOIN Categories" +
                             " ON Products.CategoryId = Categories.CategoryId" +
                             " ORDER BY CategoryName";
                SqlCommand cmdAllRows = new SqlCommand(sql, dbConnection);
                SqlDataReader reader = cmdAllRows.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string categoryName = (string)reader["CategoryName"];
                        string productName = (string)reader["ProductName"];
                        Console.WriteLine("{0}: {1}", categoryName, productName);
                    }
                }
            }
        }
    }
}