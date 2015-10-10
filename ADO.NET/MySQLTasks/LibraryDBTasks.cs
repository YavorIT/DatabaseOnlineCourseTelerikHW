namespace MySQLTasks
{
    using MySql.Data.MySqlClient;
    using System;

    class LibraryDBTasks
    {
        private const string dbConnection = @"Server=localhost;Database=library;Uid=root;Pwd=";
        public void listAllBooks(string password)
        {
            // connect to the database
            MySqlConnection dbCon = new MySqlConnection(dbConnection + password);
            // open the database
            dbCon.Open();

            using (dbCon)
            {
                MySqlCommand listAllBooks = new MySqlCommand("SELECT Title FROM books", dbCon);

                var reader = listAllBooks.ExecuteReader();
                int count = 1;
                while(reader.Read())
                {
                    System.Console.WriteLine("{0}. {1}", count, (string)reader["Title"]);
                    count++;
                }
            }

        }

        public void FindABookByName(string bookName, string password)
        {
            // connect to the database
            MySqlConnection dbCon = new MySqlConnection(dbConnection + password);
            // open the database
            dbCon.Open();

            // the sql query string to select
            string sqlCommand = string.Format("SELECT * FROM books b JOIN authors a ON b.AuthorID = a.AuthorID WHERE b.Title = '{0}'", bookName);

            using (dbCon)
            {
                MySqlCommand findBook = new MySqlCommand(sqlCommand, dbCon);

                var reader = findBook.ExecuteReader();
                while (reader.Read())
                {
                    string book = (string)reader["Title"];
                    string author = (string)reader["Name"];
                    DateTime publishDate = (DateTime)reader["PublishDate"];
                    Console.WriteLine(book  + " " + author + " " + publishDate);
                }    
            }
        }

        public void AddBook(Book bookToAdd, string password)
        {
            // connect to the database
            MySqlConnection dbCon = new MySqlConnection(dbConnection + password);
            // open the database
            dbCon.Open();

            // the sql query string to insert the book
            string addBook = string.Format("INSERT INTO books (Title, AuthorID, PublishDate, ISBN)" +
                                                            "VALUES ('{0}', {1}, STR_TO_DATE('{2}','%d/%m/%Y'), '{3}')", bookToAdd.title, bookToAdd.authorID, bookToAdd.date, bookToAdd.isbn);

            using (dbCon)
            {
                MySqlCommand addNewBook = new MySqlCommand(addBook, dbCon);

                addNewBook.ExecuteNonQuery();
            }
        }

    }
}
