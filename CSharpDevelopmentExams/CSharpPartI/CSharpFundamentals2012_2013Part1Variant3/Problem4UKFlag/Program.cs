using System;
using System.Linq;
using System.Text;

namespace Problem4UKFlag
{
    class Program
    {
        static void Main()
        {
            StringBuilder sb = new StringBuilder();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0, j = ((n - 3) / 2); i < n / 2; i++, j--)
            {
                if(j >= 0)
                sb.AppendFormat(new string('.', i) + new string('\\', 1) + new string('.', j) + new string('|', 1) + new string('.', j) + new string('/', 1) + new string('.', i) + Environment.NewLine);
            }
            sb.AppendFormat(new string('-', n / 2) + new string('*', 1) + new string('-', n / 2) + Environment.NewLine);
            var sbMirror = sb.ToString().Split('\r', '\n').ToList();
            sbMirror = sbMirror.Where(s => !string.IsNullOrEmpty(s)).ToList();
            for (int i = sbMirror.Count - 2; i >= 0; i--)
            {
                sb.Append(sbMirror[i].Replace("\\", "$").Replace("/", "\\").Replace("$", "/") + Environment.NewLine);
            }
            Console.Write(sb.ToString());
        }
    }
}
