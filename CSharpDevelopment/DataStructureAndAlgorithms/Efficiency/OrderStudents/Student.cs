namespace OrderStudents
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Course { get; set; }
        
        public Student(string firstName, string lastName, string course)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Course = course;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", FirstName, LastName);
        }
    }
}
