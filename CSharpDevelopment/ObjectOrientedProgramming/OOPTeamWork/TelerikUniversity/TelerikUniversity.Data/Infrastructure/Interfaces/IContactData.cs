using System;

namespace TelerikUniversity.Data.Infrastructure.Interfaces
{
    interface IContactData
    {
        string Address { get; set; }
        string City { get; set; }
        TelerikUniversity.Data.Enumerators.Countries Country { get; set; }
        string Email { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string PhoneNumber { get; set; }
    }
}
