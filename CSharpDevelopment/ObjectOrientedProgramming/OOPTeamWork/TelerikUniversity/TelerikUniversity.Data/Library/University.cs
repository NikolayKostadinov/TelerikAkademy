using MongoDB.Bson;
using System;
using System.Linq;
using TelerikUniversity.Data.Infrastructure;

namespace TelerikUniversity.Data.Library
{
    public class University
    {
        private ObjectId _Id = new ObjectId();
        public ObjectId Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private string universityName = "NA";
        public string UniversityName
        {
            get { return this.universityName; }
            set { this.universityName = value; }
        }

        public University(string universityName, double latitude, double longitude)
        {
            this.UniversityName = universityName;
            this.GeoLocation = new GeoLocation(latitude, longitude);
        }

        public University()
        {
            this.UniversityName = "NA";
            this.GeoLocation = new GeoLocation();
        }

        public GeoLocation GeoLocation
        {
            get;
            set;
        }        
    }
}
