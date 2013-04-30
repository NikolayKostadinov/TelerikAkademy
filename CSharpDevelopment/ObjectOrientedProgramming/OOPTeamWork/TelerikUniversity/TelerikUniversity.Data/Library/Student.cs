using MongoDB.Bson;
using System;
using System.Linq;
using TelerikUniversity.Data.Enumerators;
using TelerikUniversity.Data.Infrastructure;
using TelerikUniversity.Data.Infrastructure.Interfaces;

namespace TelerikUniversity.Data.Library
{
    public class Student : UniversityPerson
    {
        //Add, the following as per example: Course: Course 1; Group: Group 1 
        //Term: 2012/2013 period: summer, education degree: bachelor

        private ObjectId _Id = new ObjectId();
        public ObjectId Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public int FacultyNumber { get; set; }
        public SpecialityType Speciality { get; set; }

        public Student() : base()
        {
            this.FacultyNumber = 0;
            this.Speciality = SpecialityType.NotDefined;
        }

        public Student(string firstName, string lastName, Countries country, string email,
                        string address, string phoneNumber, int facultyNumber, SpecialityType speciality)
            : base(firstName, lastName, country, email, address, phoneNumber)
        {
            this.FacultyNumber = facultyNumber;
            this.Speciality = speciality;
        }

        public override string ToString()
        {
            return string.Format("Name: {0} {1}, City: {2}", this.FirstName, this.LastName, this.City);
        }

        public int Workload()
        {
            return (Configuration.RequestHoursPerWeek - this.Hours > 0 ? Configuration.RequestHoursPerWeek - this.Hours : 0);
        }

        public void Print()
        { }
    }
}
