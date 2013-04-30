using System;
using System.Linq;
using TelerikUniversity.Data.Enumerators;

namespace TelerikUniversity.Data.Infrastructure
{
    public abstract class ContactData : TelerikUniversity.Data.Infrastructure.Interfaces.IContactData
    {
        private string firstName = string.Empty;
        public string FirstName
        {
            get { return this.firstName; }
            set { firstName = value; }
        }

        private string lastName = string.Empty;
        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }

        private Countries country;//= Countries.NotDefined - it was defined, do not think it was right
        public Countries Country
        {
            get { return this.country; }
            set { country = value; }
        }

        private string city = string.Empty;
        public string City
        {
            get { return city; }
            set { city = value; }
        }

        private string email;
        private string address;
        private string phoneNumber;

        public string Email {       get { return this.email; }       set { email = value; } }
        public string Address {     get { return this.address; }     set { address = value; } }
        public string PhoneNumber { get { return this.phoneNumber; } set { phoneNumber = value; } }

        public ContactData()
            : this("NA", "NA", Countries.NotDefined, "NA", "NA", "NA")
        {
        }
        
        public ContactData(string firstName, string lastName, Countries country, string email, string address, string phoneNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Country = country;
            this.Email = email;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
        }       
    }
}