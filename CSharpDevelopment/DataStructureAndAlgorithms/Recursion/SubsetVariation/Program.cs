using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetVariation
{
    class Program
    {
        static string[] set = { "hi", "a", "b" };

        static void Main()
        {
            int k = 2;
            string[] arr = new string[k];
            int start = 0;
            StringBuilder sb = new StringBuilder();
            GenValue(0, arr, start, sb);
            Console.WriteLine(sb.ToString().Remove(sb.Length - 1, 1));
        }

        static void GenValue(int index, string[] arr, int start, StringBuilder sb)
        {
            if (index >= arr.Length)
            {
                sb.Append("(" + String.Join(" ", arr) + "),");
            }
            else
            {
                for (int i = start; i < set.Length; i++)
                {
                    arr[index] = set[i];
                    GenValue(index + 1, arr, start, sb);
                }
            }
        }
    }
}
