namespace SQLLite
{
    using System;

    class Program
    {
        static void Main()
        {
            // create the object to execute the tasks
            SQLLiteTasks taskExecutor = new SQLLiteTasks();

            // task 01 - list all books
            taskExecutor.ListAllBooks();
            Console.WriteLine("-----------------------------------------------");

            // task 02 - find a book by name
            taskExecutor.FindABook();
            Console.WriteLine("-----------------------------------------------");

            // task 03 - insert a book
            Book book = new Book("Book", 1, "1990-05-06", "1-234-324-45-768");
            taskExecutor.InsertABook(book);
            Console.WriteLine("The book is inserted!");
            Console.WriteLine("-----------------------------------------------");
        }
    }
}
