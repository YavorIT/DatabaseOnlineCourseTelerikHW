namespace SQLLite
{
    using System;
    using System.Data.SQLite;

    class SQLLiteTasks
    {
        private const string dbConnection = @"Data Source=..\..\DataBase\Library.sqlite;Version=3;";

        public void ListAllBooks()
        {
            // connect to the database
            SQLiteConnection dbCon = new SQLiteConnection(dbConnection);
            // open the database
            dbCon.Open();

            using (dbCon)
            {
                SQLiteCommand listAllBooks = new SQLiteCommand("SELECT * FROM Books b JOIN Authors a ON b.AuthorID = a.AuthorID", dbCon);

                var reader = listAllBooks.ExecuteReader();

                while(reader.Read())
                {
                    string book = (string)reader["Title"];
                    string author = (string)reader["Name"];
                    DateTime date = (DateTime)reader["PublishDate"];

                    Console.WriteLine(book + " " + author + " " + date);
                }
            }
        }

        public void FindABook()
        {
            // read the book name
            Console.Write("Enter the name of the book: ");
            string bookToFind = Console.ReadLine();

            // connect to the database
            SQLiteConnection dbCon = new SQLiteConnection(dbConnection);
            // open the database
            dbCon.Open();

            string findBookQuery = String.Format("SELECT * FROM Books b JOIN Authors a ON b.AuthorID = a.AuthorID WHERE b.Title = '{0}'", bookToFind);

            using (dbCon)
            {
                SQLiteCommand findBook = new SQLiteCommand(findBookQuery, dbCon);

                var reader = findBook.ExecuteReader();
                
                while(reader.Read())
                {
                    string book = (string)reader["Title"];
                    string author = (string)reader["Name"];
                    DateTime publishDate = (DateTime)reader["PublishDate"];
                    string isbn = (string)reader["ISBN"];

                    Console.WriteLine(book + " " + author + " " + publishDate + " " + isbn);
                }
            }
        }

        public void InsertABook(Book bookToInsert)
        {
            // connect to the database
            SQLiteConnection dbCon = new SQLiteConnection(dbConnection);
            // open the database
            dbCon.Open();

            string insertABookCommand = String.Format("INSERT INTO Books (Title, AuthorID, PublishDate, ISBN)"+
                                                         "VALUES ('{0}', {1}, '{2}', '{3}')", bookToInsert.title, bookToInsert.authorID, bookToInsert.publishDate, bookToInsert.isbn);

            using (dbCon)
            {
                SQLiteCommand insertBook = new SQLiteCommand(insertABookCommand, dbCon);

                insertBook.ExecuteNonQuery();
            }
        }
    }
}
