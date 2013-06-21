using System;
using System.Collections.Generic;
using System.Linq;

namespace MessagesInBottle
{
    class Program
    {
        static void Main()
        {
            string secretCode = Console.ReadLine();
            string cipher = Console.ReadLine();

            CipherDecoder decoder = new CipherDecoder(secretCode, cipher);

            List<string> originalMessages = decoder.Decode();

            originalMessages.Sort();

            Console.WriteLine(originalMessages.Count);
            foreach (string message in originalMessages)
            {
                Console.WriteLine(message);
            }
        }

        static int ConvertArrayToInt(int[] digits)
        {
            int result = 0;
            for (int i = 0; i < digits.Count(); i++)
            {
                result *= 10;
                result += digits[i];
            }
            return result;
        }

        static int[] ConvertNumberToArray(int number)
        {
            List<int> digits = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                digits.Add(number % 10);
                number /= 10;
            }
            digits.Reverse();
            return digits.ToArray();
        }
    }
}
