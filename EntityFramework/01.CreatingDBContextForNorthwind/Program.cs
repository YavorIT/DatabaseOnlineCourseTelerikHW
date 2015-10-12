namespace _01.CreatingDBContextForNorthwind
{
    using System;
    using System.Linq;

    public class Program
    {
        static void Main()
        {
            // test if it works
            using (var dataBase = new NORTHWNDEntities())
            {
                var employees = dataBase.Employees
                                .Select(e => new
                                {
                                   Name = e.FirstName + " " + e.LastName
                                }).ToList();

                foreach (var empl in employees)
                {
                    Console.WriteLine(empl.Name);
                }
            }                           
        }
    }
}
