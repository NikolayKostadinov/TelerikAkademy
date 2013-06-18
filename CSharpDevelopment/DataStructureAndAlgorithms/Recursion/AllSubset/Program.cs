﻿using System;
using System.Text;

namespace AllSubset
{
    class Program
    {
        static string[] set = { "test", "rock", "fun" };

        static void Main()
        {
            int k = 2;
            int[] arr = new int[k];
            int start = 0;
            StringBuilder sb = new StringBuilder();
            GenValue(0, arr, start, sb);
            Console.WriteLine(sb.ToString().Remove(sb.Length - 2, 2));
        }


        static void GenValue(int index, int[] arr, int start, StringBuilder sb)
        {
            if (index >= arr.Length)
            {
                sb.Append("(");
                for (int i = 0; i < arr.Length; i++)
                {
                    if (i == 0)
                    {
                        sb.Append(set[arr[i]] + " ");
                    }
                    else
                    {
                        sb.Append(set[arr[i]]);
                    }
                }
                sb.Append("), ");
            }
            else
            {
                for (int i = start; i <= set.Length - 1; i++)
                {
                    arr[index] = i;
                    GenValue(index + 1, arr, arr[0] + 1, sb);
                }
            }
        }
    }
}
