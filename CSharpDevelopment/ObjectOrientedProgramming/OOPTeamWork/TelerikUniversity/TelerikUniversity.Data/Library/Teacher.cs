using System;
using System.Linq;
using TelerikUniversity.Data.Enumerators;
using TelerikUniversity.Data.Infrastructure;
using TelerikUniversity.Data.Infrastructure.Interfaces;

namespace TelerikUniversity.Data.Library
{
    class Teacher : UniversityPerson
    {
        public Teacher() : base()
        {     
        }

        public Teacher(string firstName, string lastName, Countries country, string email, string address, string phoneNumber)
            : base(firstName, lastName, country, email, address, phoneNumber)
        {
        }

        public int Workload()
        {
            return (Configuration.RequestHoursPerWeek - this.Hours > 0 ? this.Hours : this.Hours + ((this.Hours - Configuration.RequestHoursPerWeek) * 2));
        }

        public void Print()
        { }
    }
}
