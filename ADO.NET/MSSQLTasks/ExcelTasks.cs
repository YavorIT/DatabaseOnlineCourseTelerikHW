namespace MSSQLTasks
{
    using System;
    using System.Data.OleDb;

    class ExcelTasks
    {
        private const string excelFile = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + "..\\..\\Excel\\Results.xlsx" + "; Extended Properties='Excel 12.0 Xml;HDR=YES;'";

        public void ReadFileAndPrintItRowByRow()
        {
            // connect to the database
            OleDbConnection oleDbCon = new OleDbConnection(excelFile);
            // open the database
            oleDbCon.Open();

            using (oleDbCon)
            {
                OleDbCommand readRowByRow = new OleDbCommand("SELECT * FROM [Results$]", oleDbCon);

                var reader = readRowByRow.ExecuteReader();

                while(reader.Read())
                {
                    string person = (string)reader["Name"];
                    double score = (double)reader["Score"];

                    Console.WriteLine("{0} - {1}", person, score);
                }
            }
        }

        public void InsertNewRowsToFile()
        {
            // connect to the database
            OleDbConnection oleDbCon = new OleDbConnection(excelFile);
            // open the database
            oleDbCon.Open();

            using (oleDbCon)
            {
                OleDbCommand insertNewRow = new OleDbCommand("INSERT INTO [Results$](Name, Score) VALUES (@Name, @Score)", oleDbCon);
                insertNewRow.Parameters.AddWithValue("@Name", "Ivan Petrov");
                insertNewRow.Parameters.AddWithValue("@Score", 30);

                insertNewRow.ExecuteNonQuery();
            }
        }
    }
}
