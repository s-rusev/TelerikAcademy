namespace _1.CategoriesRows
{
    using System;
    using System.Data.SqlClient;

    class CategoriesCount
    {
        static void Main()
        {
            SqlConnection dbConnection = new SqlConnection("Server=.\\SQLEXPRESS; " +
                                                    "Database=Northwind; Integrated Security=true");

            dbConnection.Open();
            using (dbConnection)
            {
                SqlCommand commandCount = new SqlCommand("SELECT COUNT(CategoryID) FROM Categories;", dbConnection);
                int categoriesCount = (int)commandCount.ExecuteScalar();
                Console.WriteLine("Categories count = {0}", categoriesCount);
            }
        }
    }
}