using System.Collections.Generic;

namespace CheckForPossiblePath
{
    class Program
    {
        static string[,] labyrinth = 
        {
            {" ", " ", " ", "*", " ", " ", " "},
            {"*", "*", " ", "*", " ", "*", " "},
            {" ", " ", " ", " ", " ", " ", " "},
            {" ", "*", "*", "*", "*", "*", " "},
            {" ", " ", " ", " ", " ", " ", " "},
        };

        static void Main()
        {
            labyrinth[4, 6] = "e";
            Stack<int> stack = new Stack<int>();
            CheckPath(0, 0, 0, stack);
        }

        private static bool CheckPath(int row, int col, int count, Stack<int> stack)
        {
            if (row < 0 || col < 0 ||
                row >= labyrinth.GetLength(0) || col >= labyrinth.GetLength(1))
            {
                return false;
            }

            if (labyrinth[row, col] == "e")
            {
                return true;
            }

            if (labyrinth[row, col] != " ")
            {
                return false;
            }

            stack.Push(count);
            labyrinth[row, col] = count.ToString();
            count++;
            if (CheckPath(row, col - 1, count, stack))
            {
                return true;
            }
            
            if (CheckPath(row - 1, col, count, stack))
            {
                return true;
            }

            if (CheckPath(row, col + 1, count, stack))
            {
                return true;
            }

            if (CheckPath(row + 1, col, count, stack))
            {
                return true;
            }

            labyrinth[row, col] = " ";
            if (stack.Count > 0)
            {
                stack.Pop();
            }
            return false;
        }
    }
}
