namespace _3_5FindingInformation
{
    using _01.CreatingDBContextForNorthwind;
    using System;
    using System.Linq;

    public class Program
    {
        static void Main()
        {
            // task 03 - find customers who have orders made in 1997 and shipped to Canada.
            FindCustomers();

            // task 04 - implement the previous using native sql query
            FindCustomersSqlQuery();

            // task 05 - write a method that finds all the sales by specified region and period (start / end dates).
            DateTime startDate = new DateTime(1996, 12, 4);
            DateTime endDate = new DateTime(1997, 2, 23);
            string region = "RJ";

            FindAllSalesInGivenRegionAndPeriod(startDate, endDate, region);
        }

        public static void FindCustomers()
        {
            using(var dataBase = new NORTHWNDEntities())
            {
                // select the customers which ship country is Canada
                // then find these which order date is in 1997
                // order them by name
                var customers = dataBase.Orders
                                .Where(ord => ord.ShipCountry == "Canada")
                                .Select(e => new
                                {
                                    e.Customer.ContactName,
                                    e.OrderDate
                                })
                                .ToList()
                                .FindAll(e => e.OrderDate >= Convert.ToDateTime("01/01/1997") && 
                                              e.OrderDate < Convert.ToDateTime("01/01/1998"))
                                .OrderBy(e => e.ContactName);

                // print customers name and order date
                foreach (var customer in customers)
                {
                    Console.WriteLine("{0,-20} | {1}", customer.ContactName, customer.OrderDate);
                }
            }

        }

        public static void FindCustomersSqlQuery()
        {
            string query = "SELECT c.ContactName " +
                                    "FROM Customers c " +
                                        "JOIN Orders o " +
                                             "ON c.CustomerID = o.CustomerID " +
                                    "WHERE o.ShipCountry = 'Canada' AND o.OrderDate LIKE '%1997%' " + 
                                    "ORDER BY c.ContactName";

            using (var dataBase = new NORTHWNDEntities())
            {
                var customers = dataBase.Database.SqlQuery<string>(query).ToList();

                foreach (var customer in customers)
                {
                    Console.WriteLine(customer);
                }
            }
        }

        public static void FindAllSalesInGivenRegionAndPeriod(DateTime startDate, DateTime endDate, string region)
        {
            using (var dataBase = new NORTHWNDEntities())
            {
                var salesInGivenPeriod = dataBase.Order_Details
                                         .Select(pr => new
                                         {
                                             pr.Product.ProductName,
                                             pr.Quantity,
                                             pr.UnitPrice,
                                             pr.Order.OrderDate,
                                             pr.Order.ShipRegion
                                         })
                                         .ToList()
                                         .FindAll(s => s.OrderDate >= startDate && s.OrderDate <= endDate && s.ShipRegion == region);

                Console.WriteLine("\nRegion | Product | Quantity | Unit Price | Date\n");
                foreach (var sale in salesInGivenPeriod)
                {
                    Console.WriteLine("{0,-3} | {1,-35} | {2,-3} | {3,-5:00:00} | {4}", sale.ShipRegion, 
                                                                            sale.ProductName, 
                                                                            sale.Quantity, 
                                                                            sale.UnitPrice, 
                                                                            sale.OrderDate);
                }

            }
        }
    }
}
