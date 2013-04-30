using MongoDB.Driver;
using System;

namespace TelerikUniversity.Data.Exceptions
{
    public class DataBaseConnectionException : MongoConnectionException
    { 
        public DataBaseConnectionException(string message)
            : base(message)
        {
        }
    }
}