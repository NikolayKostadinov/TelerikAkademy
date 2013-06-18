using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAllAreas
{
    class Program
    {
        static string[,] labyrinth = 
        {
            {" ", " ", " ", "*", " ", " ", " "},
            {" ", " ", " ", "*", " ", " ", " "},
            {" ", " ", " ", " ", "*", " ", " "},
            {" ", " ", " ", " ", "*", " ", " "},
            {" ", " ", " ", " ", "*", " ", " "},
        };

        private static int maxSum = 0;

        static void Main()
        {

            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {
                    if (labyrinth[row, col] == " ")
                    {
                        DFS(row, col, 0);
                        Console.WriteLine(maxSum);
                        maxSum = 0;
                    }
                }
            }
        }

        static void DFS(int row, int col, int count)
        {
            if (count > maxSum)
            {
                maxSum = count;
            }

            if (row < 0 || col < 0 ||
                row >= labyrinth.GetLength(0) || col >= labyrinth.GetLength(1) ||
                labyrinth[row, col] != " ")
            {
                return;
            }

            labyrinth[row, col] = count.ToString();

            count++;
            DFS(row, col - 1, count);
            DFS(row - 1, col, count);
            DFS(row, col + 1, count);
            DFS(row + 1, col, count);
        }
    }
}
