using System;
using System.Linq;
using EntityFramework.Data;

namespace EntityFramework
{
    class Program
    {
        static void Main()
        {
            var dbSearch = SessionState.db.Customers.ToList();
            foreach (var customer in dbSearch)
            {
                Console.WriteLine(customer.ContactName);
            }
        }
    }
}
