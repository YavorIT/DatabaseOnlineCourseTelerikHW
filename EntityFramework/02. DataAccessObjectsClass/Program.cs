// NOTE: if you want to see each method's work - comment the others

namespace _02.DataAccessObjectsClass
{
    using _01.CreatingDBContextForNorthwind;
    using System.Linq;

    public class Program
    {
        static void Main()
        {
            using (var dataBase = new NORTHWNDEntities())
            {
                InsertNewCustomer(dataBase);

                ModifyCustomer(dataBase);

                DeleteCustomer(dataBase);
            }
        }

        public static void InsertNewCustomer(NORTHWNDEntities dataBase)
        {
            var newCustomer = new Customer
            {
                CustomerID = "ABGRT",
                CompanyName = "Nike",
                ContactName = "Miroslav Andonov",
                ContactTitle = "Owner",
                Address = "Mladost 4",
                City = "Sofia",
                Region = "Sofia",
                PostalCode = "1612",
                Country = "Bulgaria",
                Phone = "3-432-213-4",
                Fax = "3-324-213-12",
            };

            dataBase.Customers.Add(newCustomer);

            dataBase.SaveChanges();
        }

        public static void ModifyCustomer(NORTHWNDEntities dataBase)
        {
            // selecting the new inserted customer entry to modify it
            var customer = dataBase.Customers
                            .Where(c => c.CustomerID == "ABGRT")
                            .FirstOrDefault();

            customer.ContactName = "Miroslav Ivanov";

            dataBase.SaveChanges();
        }

        public static void DeleteCustomer(NORTHWNDEntities dataBase)
        {
            var customer = dataBase.Customers
                           .Where(c => c.CustomerID == "ABGRT")
                           .FirstOrDefault();

            dataBase.Customers.Remove(customer);

            dataBase.SaveChanges();
        }
    }
}
