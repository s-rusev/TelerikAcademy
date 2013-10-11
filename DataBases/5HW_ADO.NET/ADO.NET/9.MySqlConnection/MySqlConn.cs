namespace _9.MySqlConnection
{
    using System;
    using System.Linq;
    using MySql.Data.MySqlClient;

    public class MySqlConn
    {
        static readonly string connection = "Server=localhost; Port=3306; Database=bookStores; Uid=root; Pwd=1234; pooling=true";

        static void Main()
        {
            ReadBooksInfo();
            SearchForBook("Book");
            AddBook("Book", new DateTime(2012, 5, 2), 226344556, "Ivan Ivanov");
        }

        private static void AddBook(string bookName, DateTime datePublish, long isbn, string author)
        {
            MySqlConnection dbConnection = new MySqlConnection(connection);

            dbConnection.Open();
            using (dbConnection)
            {
                string bookStr = "INSERT INTO books " +
                                 "(titleBook, publishDate, ISBN) VALUES " +
                                 "(@title, @date, @isbn)";
                MySqlCommand addBook = new MySqlCommand(bookStr, dbConnection);
                addBook.Parameters.AddWithValue("@title", bookName);
                addBook.Parameters.AddWithValue("@date", datePublish);
                addBook.Parameters.AddWithValue("@isbn", isbn);
                addBook.ExecuteNonQuery();

                MySqlCommand cmdSelectIdentity = new MySqlCommand("SELECT @@Identity", dbConnection);
                ulong insertedRecordId = (ulong)cmdSelectIdentity.ExecuteScalar();

                string authorStr = "INSERT INTO authors " +
                                   "(Books_idBooks, AuthorName) VALUES " +
                                   "(@bookId, @name)";
                MySqlCommand addAuthor = new MySqlCommand(authorStr, dbConnection);
                addAuthor.Parameters.AddWithValue("@bookId", (int)insertedRecordId);
                addAuthor.Parameters.AddWithValue("@name", author);
                addAuthor.ExecuteNonQuery();
            }
        }

        private static void SearchForBook(string input)
        {
            MySqlConnection dbConnection = new MySqlConnection(connection);

            dbConnection.Open();
            using (dbConnection)
            {
                string sqlStr = "USE `bookStores` ; SELECT AuthorName, titleBook, publishDate, ISBN  FROM books " +
                                "JOIN authors " +
                                "ON authors.Books_idBooks = books.idBooks " +
                                "WHERE titleBook LIKE @input";
                MySqlParameter cmdParam = new MySqlParameter("@input", "%" + input + "%");
                MySqlCommand cmd = new MySqlCommand(sqlStr, dbConnection);
                cmd.Parameters.Add(cmdParam);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string author = (string)reader["AuthorName"];
                    string title = (string)reader["titleBook"];
                    DateTime date = (DateTime)reader["publishDate"];
                    long isbn = (long)reader["ISBN"];
                    Console.WriteLine("{0}: {1} {2} {3}", author, title, date, isbn);
                }
            }
        }

        private static void ReadBooksInfo()
        {
            MySqlConnection dbConnection = new MySqlConnection(connection);

            dbConnection.Open();
            using (dbConnection)
            {
                string sqlStr = "USE `bookStores` ; SELECT AuthorName, titleBook, publishDate, ISBN  FROM books " +
                                "JOIN authors " +
                                "ON authors.Books_idBooks = books.idBooks";
                MySqlCommand cmd = new MySqlCommand(sqlStr, dbConnection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string author = (string)reader["AuthorName"];
                    string title = (string)reader["titleBook"];
                    DateTime date = (DateTime)reader["publishDate"];
                    long isbn = (long)reader["ISBN"];
                    Console.WriteLine("{0}: {1} {2} {3}", author, title, date, isbn);
                }
            }
        }
    }
}