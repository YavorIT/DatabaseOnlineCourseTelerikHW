namespace _08.InheritingTheEmployeeClass
{
    using _01.CreatingDBContextForNorthwind;
    using System;
    using System.Linq;

    public partial class EmployeeExtended : Employee
    {
        public void CorrespondingTerritories()
        {
            using (var db = new NORTHWNDEntities())
            {
                // do this foreach employee and it's territories
                foreach (var employee in db.Employees.Include("Territories").ToList()) // i don't know why this work but not (e => e.Territories)
                {                                                                      // if you can tell me i'll be happy. Thank you.
                    // select employee name and territory description
                    var correspondingTerritories = employee.Territories.Select(t => new
                    {
                        territories = t.TerritoryDescription,
                        Name = employee.FirstName + " " + employee.LastName
                    }).ToList();

                    // print the result
                    foreach (var emp in correspondingTerritories)
                    {
                        Console.WriteLine("{0} - {1}", emp.Name, emp.territories);
                    }
                }
               
            }
        }
    }
}
