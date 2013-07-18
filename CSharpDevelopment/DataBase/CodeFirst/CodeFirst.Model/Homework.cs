using System;

namespace CodeFirst.Model
{
    public class Homework
    {
        public int Id { get; set; }

        //public int StudentId { get; set; }
        //public Student Student { get; set; }

        //public int CourseId { get; set; }
        //public Student Course { get; set; }

        public string Content { get; set; }
        public DateTime? TimeSent { get; set; }

    }
}
