using System;
using System.Linq;
using TelerikUniversity.Data.Enumerators;
using TelerikUniversity.Data.Infrastructure;
using TelerikUniversity.Data.Infrastructure.Interfaces;

namespace TelerikUniversity.Data.Library
{
    class Assistant : UniversityPerson
    {
        public Assistant()
            : base()
        {
        }

        public Assistant(string firstName, string lastName, Countries country, string email, string address, string phoneNumber)
            : base(firstName, lastName, country, email, address, phoneNumber)
        {
        }

        public int Workload()
        {
            return this.Hours;
        }

        public void Print()
        { }
    }
}
