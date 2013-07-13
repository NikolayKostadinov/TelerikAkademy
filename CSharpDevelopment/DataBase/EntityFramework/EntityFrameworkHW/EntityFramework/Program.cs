using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Data;

namespace EntityFramework
{
    class Program
    {
        static void Main()
        {
            NORTHWNDEntities db = new NORTHWNDEntities();
            var dbSearch = db.Customers.ToList();
            foreach (var customer in dbSearch)
            {
                Console.WriteLine(customer.ContactName);
            }
        }
    }
}
