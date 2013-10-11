namespace _4.AddProduct
{
    using System;
    using System.Data.SqlClient;

    public class AddProduct
    {
        static void Main()
        {
            SqlConnection dbConnection = new SqlConnection("Server=.\\SQLEXPRESS; " +
                                                    "Database=Northwind; Integrated Security=true");
            dbConnection.Open();
            using (dbConnection)
            {
                int addedRow = InsertInProducts("AddedProduct", 1, 2, "1000 kg", 0.70m, dbConnection);
                Console.WriteLine("Added one row on line: {0}", addedRow);
            }
        }

        static int InsertInProducts(string productName, int supplierID, int categoryID, string quantity, decimal price, SqlConnection dbCon)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Products " +
                                            "(ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice) VALUES " +
                                            "(@name, @supplier, @category, @quantity, @price)", dbCon);
            cmd.Parameters.AddWithValue("@name", productName);
            cmd.Parameters.AddWithValue("@supplier", supplierID);
            cmd.Parameters.AddWithValue("@category", categoryID);
            cmd.Parameters.AddWithValue("@quantity", quantity);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.ExecuteNonQuery();

            SqlCommand cmdSelectIdentity = new SqlCommand("SELECT @@Identity", dbCon);
            int insertedRecordId = (int)(decimal)cmdSelectIdentity.ExecuteScalar();

            return insertedRecordId;
        }
    }
}