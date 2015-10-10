namespace MSSQLTasks
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            // Make an object to use the class for the first 5 tasks
            NorthWindTasks taskExecutorNW = new NorthWindTasks();


            // task 01 - retrieve the number of rows in the categories table Northwind DB
            int rowsInCategories = taskExecutorNW.GetNumberOfRowsInCategories();
            Console.WriteLine("The number of rows in the categories table is: {0}", rowsInCategories);
            Console.WriteLine("--------------------------------------------------------------------------------");


            // task 02 - get the name and description of all categories
            var nameAndDescription = new Dictionary<string, string>();
            taskExecutorNW.GetNameAndDescriptionOfCategories(nameAndDescription);
            Console.WriteLine("\t\tName - Description\n");
            Print(nameAndDescription);
            Console.WriteLine("--------------------------------------------------------------------------------");


            // task 03 - get the categories and the products in them
            taskExecutorNW.GetNamesOfProductsAndProductsCategories();
            Console.WriteLine("--------------------------------------------------------------------------------");


            // task 04 - add a new product to the products table
            Product milkaChocolate = new Product("Chocolate", 8, 2, "100g in package", 2.00M, 25, 10, 5, false);
            taskExecutorNW.AddProductToProducts(milkaChocolate);
            Console.WriteLine("The product is added!");
            Console.WriteLine("--------------------------------------------------------------------------------");


            // task 05 - retrieve the images for all categories and store them as jpg files on the file system
            taskExecutorNW.GetImages();
            Console.WriteLine("Images Are Saved!");
            Console.WriteLine("--------------------------------------------------------------------------------");


            // task 06 - read the excel file row by row through OLE DB
            ExcelTasks taskExecutorExcel = new ExcelTasks();
            taskExecutorExcel.ReadFileAndPrintItRowByRow();
            Console.WriteLine("--------------------------------------------------------------------------------");


            //task 07 - insert data to the excel file
            taskExecutorExcel.InsertNewRowsToFile();
            Console.WriteLine("The new data is inserted!");
            Console.WriteLine("--------------------------------------------------------------------------------");

            // task 08 - search product by pattern
            taskExecutorNW.SearchProductsByPattern();
            Console.WriteLine("--------------------------------------------------------------------------------");
        }

        // Method for printing the dictionary
        private static void Print(Dictionary<string, string> nameAndDescription)
        {
            foreach (var row in nameAndDescription)
            {
                Console.WriteLine("{0} - {1}", row.Key, row.Value);
            }
        }
    }
}
