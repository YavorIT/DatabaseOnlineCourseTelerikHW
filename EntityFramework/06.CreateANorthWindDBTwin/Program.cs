namespace _06.CreateANorthWindDBTwin
{
    using _01.CreatingDBContextForNorthwind;
    using System;

    // NOTE: In order to create the database you should modify your App.config
    class Program
    {
        static void Main()
        {
            using (var dataBase = new NORTHWNDEntities())
            {
                bool isCreated = dataBase.Database.CreateIfNotExists();
                Console.WriteLine("The database was created: {0}", isCreated);
            }
        }
    }
}
