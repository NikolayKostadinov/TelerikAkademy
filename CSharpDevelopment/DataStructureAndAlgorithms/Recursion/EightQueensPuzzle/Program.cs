using System;

namespace EightQueensPuzzle
{
    class Program
    {
        private static int queens = 8;
        private static int matrixLenght = 8;
        static int[,] matrix = new int[matrixLenght, matrixLenght];
        static void Main()
        {
            int startPosition = 0;
            while(queens > 0)
            {
                PutQueen(startPosition, 0);
                Start(0);
                startPosition++;
            }
        }

        private static void Start(int startPosition)
        {
            for (int row = startPosition; row < matrixLenght; row++)
            {
                for (int col = 0; col < matrixLenght; col++)
                {
                    if (matrix[row, col] == 0)
                    {
                        PutQueen(row, col);
                        Print();
                        Console.WriteLine();
                    }
                }
            }
            if (queens > 0)
            {
                queens = 8;
                matrix = new int[matrixLenght, matrixLenght];
            }
        }

        private static void Print()
        {
            for (int row = 0; row < matrixLenght; row++)
            {
                for (int col = 0; col < matrixLenght; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void PutQueen(int row, int col)
        {
            queens--;
            matrix[row, col] = 9;
            SetBeatenField(row, col);
        }
  
        private static void SetBeatenField(int row, int col)
        {
            //cols
            for (int i = 0; i < matrixLenght; i++)
            {
                if(matrix[row, i] < 9)
                {
                    matrix[row, i]++;
                }
            }

            //rows
            for (int i = 0; i < matrixLenght; i++)
            {
                if (matrix[i, col] < 9)
                {
                    matrix[i, col]++;
                }
            }

            //topleft
            var startRow = 0;
            var startCol = 0;
            startCol = col - row;
            for (int i = 0; i < matrixLenght; i++)
            {
                if (startRow + i < matrixLenght && startCol + i < matrixLenght && startCol + i >=0 && matrix[startRow + i, startCol + i] < 9)
                {
                    matrix[startRow + i, startCol + i]++;
                }
            }

            //topright
            startCol = col + row;
            if (startCol >= matrixLenght)
            {
                startCol = matrixLenght - 1;
            }
            for (int i = 0; i < matrixLenght; i++)
            {
                if (startRow + i < matrixLenght && startCol - i >= 0 && matrix[startRow + i, startCol - i] < 9)
                {
                    matrix[startRow + i, startCol - i]++;
                }
            }
        }
    }
}
