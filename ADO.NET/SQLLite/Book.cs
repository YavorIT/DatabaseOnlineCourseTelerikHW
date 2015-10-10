using System;

namespace SQLLite
{
    class Book
    {
        public string title;
        public int authorID;
        public string publishDate;
        public string isbn;

        public Book(string title, int author, string date, string isbn)
        {
            this.title = title;
            this.authorID = author;
            this.publishDate = date;
            this.isbn = isbn;
        }

    }
}
