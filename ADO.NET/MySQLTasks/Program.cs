namespace MySQLTasks
{
    using System;

    class Program
    {
        static void Main()
        {
            // create an object to execute the tasks
            LibraryDBTasks taskExecutor = new LibraryDBTasks();
            Console.Write("Enter pass: ");
            string pass = Console.ReadLine();

            // task 01 - list all books
            taskExecutor.listAllBooks(pass);
            Console.WriteLine("--------------------------------------------");

            // task 02 - find a book by name
            Console.Write("Enter the book's name: ");
            string bookName = Console.ReadLine();
            taskExecutor.FindABookByName(bookName, pass);
            Console.WriteLine("--------------------------------------------");

            // task 03 - add new book

            //creating the book object
            Book bookToAdd = new Book("Book", 3, "10/04/2000", "4-231-432-23-432");
            // executing the task
            taskExecutor.AddBook(bookToAdd, pass);
            Console.WriteLine("Book added!");
            Console.WriteLine("--------------------------------------------");

        }
    }
}
