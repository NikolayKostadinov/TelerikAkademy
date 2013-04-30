using System;
using System.Linq;
using TelerikUniversity.Data.Enumerators;

namespace TelerikUniversity.Data.Infrastructure
{
    public abstract class UniversityPerson : ContactData, TelerikUniversity.Data.Infrastructure.Interfaces.IWorkable
    {
        private int hours;

        public int Hours
        {
            get { return this.hours; }
            set { this.hours = value; }
        }

        public UniversityPerson()
            : base()
        {
        }

        public UniversityPerson(string firstName, string lastName, Countries country, string email, string address, string phoneNumber)
            : base(firstName, lastName, country, email, address, phoneNumber)
        {
            this.hours = 0;
        }

        public int Workload()
        {
            throw new NotImplementedException();
        }
    }
}