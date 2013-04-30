using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikUniversity.Data.Infrastructure;
using TelerikUniversity.Data.Enumerators;

namespace TelerikUniversity.Data.Library
{
    class UserProfile : ContactData
    {
        private string password;
        internal string Password
        {
            set { this.password = value;  }
        }

        private string userName;
        internal string UserName
        {
            get { return this.userName; }
            set { this.userName = value; }
        }
    
        public UserProfile(string firstName, string lastName, Countries country, 
                           string email, string address, string phoneNumber,
                           string password, string userName )
            : base(firstName, lastName, country, email, address, phoneNumber)
        {
            this.UserName = userName;
            this.Password = password;            
        }
    }
}
