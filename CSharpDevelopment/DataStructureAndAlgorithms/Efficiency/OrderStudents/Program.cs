using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OrderStudents
{
    class Program
    {
        static void Main()
        {
            SortedDictionary<string, List<Student>> students = new SortedDictionary<string, List<Student>>();

            string line;
            using (StreamReader reader = new StreamReader(@"..\..\students.txt"))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    string[] content = line.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    Student student = new Student(content[0].Trim(), content[1].Trim(), content[2]);
                    if (students.ContainsKey(student.Course))
                    {
                        students[student.Course].Add(student);
                    }
                    else
                    {
                        students.Add(student.Course, new List<Student>() {student});
                    }
                }
            }

            foreach (var student in students)
            {
                Console.WriteLine("{0}: {1}", student.Key, string.Join(", ", student.Value.OrderBy(s => s.FirstName).ToList()));
            }
        }
    }
}
