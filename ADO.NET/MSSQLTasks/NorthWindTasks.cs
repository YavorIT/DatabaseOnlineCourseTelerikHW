namespace MSSQLTasks
{
    using System.Data.SqlClient;
    using System.Collections.Generic;
    using System.IO;
    using System.Drawing;
    using System;
    using System.Text;

    class NorthWindTasks
    {
        // starting byte for jpeg formats
        private const int jpg_File_Starting_Position = 78;

        // NOTE: You have to change the server host from YAVOR-PC to your host.
        // The string below is made to work on SQLEXPRESS.
        private const string dbConnectionEXPRESS = @"Server=YAVOR-PC\SQLEXPRESS; Database=NORTHWND; Integrated Security=true";

        public int GetNumberOfRowsInCategories()
        {
            // Connect to the database
            SqlConnection dbCon = new SqlConnection(dbConnectionEXPRESS);

            // Open the database
            dbCon.Open();

            // variable to store the number of rows
            int rowsCount;


            using (dbCon)
            {
                // make a new SQL command to return the count of the rows
                SqlCommand getNumberOfRows = new SqlCommand("SELECT COUNT(*) FROM Categories", dbCon);

                // execute the command and return the result to the variable
                rowsCount = (int)getNumberOfRows.ExecuteScalar();
            }

            return rowsCount;
        }

        public Dictionary<string, string> GetNameAndDescriptionOfCategories(Dictionary<string, string> nameAndDescription)
        {
            // Connect to the database
            SqlConnection dbCon = new SqlConnection(dbConnectionEXPRESS);

            // Open the database
            dbCon.Open();

            using (dbCon)
            {
                SqlCommand getNameAndDescription = new SqlCommand("SELECT CategoryName, Description FROM Categories", dbCon);
                var reader = getNameAndDescription.ExecuteReader();

                while (reader.Read())
                {
                    nameAndDescription.Add((string)reader["CategoryName"], (string)reader["Description"]);
                }
            }

            return nameAndDescription;
        }

        public void GetNamesOfProductsAndProductsCategories()
        {
            // Connect to the database
            SqlConnection dbCon = new SqlConnection(dbConnectionEXPRESS);

            // Open the database
            dbCon.Open();

            using (dbCon)
            {
                SqlCommand getProductsNamesAndCategories = new SqlCommand("SELECT p.ProductName, c.CategoryName " +
                                                                              "FROM Categories c " +
                                                                              "JOIN Products p " +
                                                                              "ON p.CategoryID = c.CategoryID " +
                                                                              "ORDER BY c.CategoryName", dbCon);
                var reader = getProductsNamesAndCategories.ExecuteReader();

                while (reader.Read())
                {
                    string productName = (string)reader["ProductName"];
                    string categoryName = (string)reader["CategoryName"];

                    System.Console.WriteLine("{0} - {1}", categoryName, productName);
                }
            }
        }

        public void AddProductToProducts(Product productToAdd)
        {
            // connect to the database
            SqlConnection dbCon = new SqlConnection(dbConnectionEXPRESS);

            // Open the database
            dbCon.Open();

            string sqlQuery = "INSERT INTO Products(ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued) " +
                                                            "VALUES (@ProductName, @SupplierID, @CategoryID, @QuantityPerUnit, @UnitPrice, @UnitsInStock, @UnitsOnOrder, @ReorderLevel, @Discontinued)";

            using (dbCon)
            {
                SqlCommand insertProduct = new SqlCommand(sqlQuery, dbCon);

                // set the parameters' values
                insertProduct.Parameters.AddWithValue("@ProductName", productToAdd.productName);
                insertProduct.Parameters.AddWithValue("@SupplierID", productToAdd.supplierID);
                insertProduct.Parameters.AddWithValue("@CategoryID", productToAdd.categoryID);

                insertProduct.Parameters.AddWithValue("@QuantityPerUnit", productToAdd.quantityPerUnit);
                insertProduct.Parameters.AddWithValue("@UnitPrice", productToAdd.unitPrice);
                insertProduct.Parameters.AddWithValue("@UnitsInStock", productToAdd.unitsInStock);

                insertProduct.Parameters.AddWithValue("@UnitsOnOrder", productToAdd.unitsOnOrder);
                insertProduct.Parameters.AddWithValue("@ReorderLevel", productToAdd.reorderLevel);
                insertProduct.Parameters.AddWithValue("@Discontinued", productToAdd.Discontinued);

                // execute the command
                insertProduct.ExecuteNonQuery();
            }
        }

        public void GetImages()
        {
            // connect to the database
            SqlConnection dbCon = new SqlConnection(dbConnectionEXPRESS);
            // open the database
            dbCon.Open();

            using (dbCon)
            {
                SqlCommand selectAllCategoriesImages = new SqlCommand("SELECT CategoryName, Picture FROM Categories", dbCon);

                var reader = selectAllCategoriesImages.ExecuteReader();

                while(reader.Read())
                {
                    byte[] image = (byte[])reader["Picture"];
                    string fileName = @"..\..\Images\" + (string)reader["CategoryName"] + ".jpg";

                    // using the replace method to remove the "/" from the file name becuse it will result in GDI+ exception.
                    fileName = fileName.Replace("/", "And");
                    WriteImage(image, fileName);
                }
            }
        }

        private void WriteImage(byte[] image, string fileName)
        {
            var memSym = new MemoryStream(image, jpg_File_Starting_Position, image.Length - jpg_File_Starting_Position);
            
            using (memSym)
            {
                Image picture = Image.FromStream(memSym);

                picture.Save(fileName);
            }
        }

        public void SearchProductsByPattern()
        {
            // read the user input
            Console.Write("Enter the product symbols: ");
            string input = Console.ReadLine();

            // handle the special characters
            string pattern = ExtractPatternFrom(input);

            // connect to the database
            SqlConnection dbCon = new SqlConnection(dbConnectionEXPRESS);

            // open the database
            dbCon.Open();

            using (dbCon)
            {
                SqlCommand selectProducts = new SqlCommand(@"SELECT ProductName FROM Products WHERE ProductName LIKE '%' + @pattern + '%'", dbCon);
                // declare the pattern variable
                selectProducts.Parameters.AddWithValue("@pattern", pattern);

                var reader = selectProducts.ExecuteReader();

                while(reader.Read())
                {
                    Console.WriteLine((string)reader["ProductName"]);
                }
            }
        }

        private string ExtractPatternFrom(string input)
        {
            StringBuilder pattern = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsLetter(input[i]))
                {
                    pattern.Append(input[i]);
                }
            }

            return pattern.ToString();
        }
    }
}
