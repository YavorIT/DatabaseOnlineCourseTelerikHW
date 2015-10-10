namespace MySQLTasks
{
    class Book
    {
        public string title;
        public int authorID;
        public string date;
        public string isbn;

        public Book(string title, int authorID, string date, string isbn)
        {
            this.title = title;
            this.authorID = authorID;
            this.date = date;
            this.isbn = isbn;
        }
    }
}
