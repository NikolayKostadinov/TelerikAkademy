using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TelerikUniversity.Data.Extensions
{
    public static class Helpers
    {
        public static int ToInt(this string str)
        {
            int num;
            if (str != null && int.TryParse(str, out num))
                return num;
            return int.MinValue;
        }

        public static List<string> LoadFile(string filePath)
        {
            List<string> result = new List<string>();
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        result.Add(line);
                        line = reader.ReadLine();
                    }
                }
            }
            return result;
        }
    }
}
