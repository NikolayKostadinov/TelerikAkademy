using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublePassword
{
    class Program
    {
        static void Main()
        {
            string str = Console.ReadLine();
            if (str.Contains("*"))
            {
                var asteriks = from s in str
                                group s by s
                                into g
                                select new
                                    {
                                        key = g.Key,
                                        count = g.Count()
                                    };

            }
            else
            {
                Console.WriteLine(1);
            }
        }
    }
}
