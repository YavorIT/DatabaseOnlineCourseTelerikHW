namespace _07.MultiThreadingSimulation
{
    using _01.CreatingDBContextForNorthwind;
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            // creating one of the database contexts used to simulate the multithreading
            using (var firstDataBase = new NORTHWNDEntities())
            {

                // selecting the first employee
                var employee = firstDataBase.Employees.FirstOrDefault();

                // changing the employee's country to Bulgaria
                employee.Country = "Bulgaria";

                //creating the second database
                using (var secondDataBase = new NORTHWNDEntities())
                {

                    // selecting the first employee again
                    var employeeSecond = secondDataBase.Employees.FirstOrDefault();

                    // changing the employee's country to England
                    employee.Country = "England";

                    secondDataBase.SaveChanges();
                } // here the second connection is closed

                firstDataBase.SaveChanges();
            }// first connection is closed

            // show the actual result
            using (var dbToShowResult = new NORTHWNDEntities())
            {
                var result = dbToShowResult.Employees.FirstOrDefault();

                Console.WriteLine("The first emplyee's country is: {0}", result.Country);
            }
        }
    }
}
