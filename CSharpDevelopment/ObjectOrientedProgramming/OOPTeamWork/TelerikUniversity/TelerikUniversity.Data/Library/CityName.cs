using MongoDB.Bson;
using System;
using System.Linq;

namespace TelerikUniversity.Data.Library
{
    public class CityName
    {
        private ObjectId _Id = new ObjectId();
        public ObjectId Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private string name;
        public string Name 
        { 
            get { return this.name; }
            set { this.name = value; } 
        }
    }
}
