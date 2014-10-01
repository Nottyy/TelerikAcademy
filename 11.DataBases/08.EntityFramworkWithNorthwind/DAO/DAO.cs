namespace DAO
{
    //02.Create a DAO class with static methods which provide 
    //functionality for inserting, modifying and deleting customers. 
    //Write a testing class.

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data.Entity;
    using System.Data;
    using NorthwindModel;

    public class DAO
    {
        public static void Main()
        {
            //AddCustomer("GOPIS", "Krali Marko");
            //ModifyCustomer("GOPIS", "Evala Gope");
            //DeleteCustomer("GOPIS");
            //FindCustomerOrders(1997, "Canada");
            //PrintOrdersWithSQL(1997, "Canada");
            //FindSales("RJ", new DateTime(1995, 5, 1), new DateTime(1998, 5, 1));
        }

        public static void AddCustomer(string id, string companyName)
        {
            var customer = new Customer
            {
                CustomerID = id,
                CompanyName = companyName
            };

            NorthwindEntities db = new NorthwindEntities();

            if (!CustomerExistsInDb(db, id))
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                Console.WriteLine("Company added -> {0}", companyName);
            }
            else
            {
                throw new ArgumentException("There is already a person with the same id in the databse!");
            }
        }

        public static void ModifyCustomer(string id, string newCompanyName)
        {
            NorthwindEntities db = new NorthwindEntities();

            if (CustomerExistsInDb(db, id))
            {
                var currentCompanyName = db.Customers.Where(c => c.CustomerID == id).First().CompanyName;
                db.Customers.Where(c => c.CustomerID == id).First().CompanyName = newCompanyName;
                db.SaveChanges();
                Console.WriteLine("Changed company name: {0} -> {1}", currentCompanyName, newCompanyName);
            }
            else
            {
                throw new ArgumentException("There is not a company with the id -> {0}", id);
            }
        }

        public static void DeleteCustomer(string id)
        {
            var db = new NorthwindEntities();

            if (CustomerExistsInDb(db, id))
            {
                var customer = db.Customers.Where(c => c.CustomerID == id).FirstOrDefault();
                db.Customers.Remove(customer);
                db.SaveChanges();
                Console.WriteLine("Deleted customer with id -> {0}", id);
            }
            else
            {
                throw new ArgumentException("There is not a company with the id -> {0}", id);
            }
        }

        public static bool CustomerExistsInDb(NorthwindEntities db, string id)
        {
            bool exists = db.Customers.Any(c => c.CustomerID == id);
            return exists;
        }

        //03.Write a method that finds all customers who have orders made in 1997 and shipped to Canada.
        public static void FindCustomerOrders(int year, string country)
        {
            var db = new NorthwindEntities();
            var orders = db.Orders.Where(o => o.OrderDate.Value.Year == year && o.ShipCountry == country).GroupBy(c => c.Customer);

            int n = 1;

            foreach (var order in orders)
            {
                Console.WriteLine("{0}. {1} -> {2}", n, order.Key.ContactName, order.Key.CompanyName);
                n++;
            }
        }

        //04. Implement previous by using native SQL query and executing it through the ObjectContext.
        public static void PrintOrdersWithSQL(int year, string country)
        {
            using (var db = new NorthwindEntities())
            {
                string commandStringSQL =
                "SELECT c.CustomerID " +
                "FROM Customers c " +
                "JOIN Orders o " +
                "ON c.CustomerID = o.CustomerID " +
                "WHERE YEAR(o.OrderDate) = {0} " +
                "AND o.ShipCountry = {1} " +
                "group by c.CustomerID";

                object[] parameters = { year, country };
                var customers = db.Database.SqlQuery<string>(commandStringSQL, parameters);

                foreach (var item in customers)
                {
                    Console.WriteLine(item);
                }
            }
        }

        //05.Write a method that finds all the sales by specified region and period (start / end dates).

        public static void FindSales(string region, DateTime startDate, DateTime endDate)
        {
            var db = new NorthwindEntities();
            var sales = db.Orders.Where(o => o.ShipRegion == region && o.OrderDate > startDate && o.OrderDate < startDate)
                .Select(s => new { NewShipdate = s.ShippedDate, NewRegion = s.ShipRegion });

            foreach (var sale in sales)
            {
                Console.WriteLine("{0} - {1}", sale.NewRegion, sale.NewShipdate);
            }
        }
    }
}
