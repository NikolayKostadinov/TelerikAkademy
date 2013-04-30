using System;
using System.Linq;

namespace TelerikUniversity.Data.Infrastructure
{
    public struct GeoLocation
    {
        private double latitude;
        public double Latitude
        {
            get { return this.latitude; }
            set { this.latitude = value; }
        }

        private double longitude;
        public double Longitude 
        {
            get { return this.longitude; }
            set { this.longitude = value; } 
        }
        
        public GeoLocation(double latitude, double longitude)
            : this()
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }
    }
}
