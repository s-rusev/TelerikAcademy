namespace _8.SearchProducts
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;

    public class SearchProducts
    {
        static void Main()
        {
            string userSearch = "Chai";//Console.ReadLine();
            List<string> allProducts = GetProducts(userSearch);

            Console.WriteLine("All matching products are:");
            foreach (var item in allProducts)
            {
                Console.WriteLine(item);
            }
        }

        private static List<string> GetProducts(string input)
        {
            List<string> allProducts = new List<string>();

            SqlConnection dbConnection = new SqlConnection("Server=.\\SQLEXPRESS; " +
                                                    "Database=Northwind; Integrated Security=true");
            dbConnection.Open();
            using (dbConnection)
            {
                string sql = "SELECT ProductName FROM Products where ProductName LIKE @input";
                SqlParameter userInput = new SqlParameter("@input", "%" + input + "%");
                SqlCommand cmdAllRows = new SqlCommand(sql, dbConnection);
                cmdAllRows.Parameters.Add(userInput);

                SqlDataReader reader = cmdAllRows.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        allProducts.Add((string)reader["ProductName"]);
                    }
                }
            }

            return allProducts;
        }
    }
}