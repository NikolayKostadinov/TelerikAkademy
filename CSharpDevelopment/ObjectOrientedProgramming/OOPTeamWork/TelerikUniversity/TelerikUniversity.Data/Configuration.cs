using MongoDB.Driver;
using System;
using System.Configuration;
using System.Linq;

namespace TelerikUniversity.Data
{
    public static class Configuration
    {
        private static int requestHoursPerWeek = 40;
        public static int RequestHoursPerWeek
        {
            get { return requestHoursPerWeek; } 
        }

        public static MongoDatabase db
        {
            get
            {
                var connectionstring = ConfigurationManager.AppSettings["MONGOLAB_URI"];
                string dbName = MongoUrl.Create(connectionstring).DatabaseName;
                MongoServer dbServer = MongoServer.Create(connectionstring);
                MongoDatabase dbConnection = dbServer.GetDatabase(dbName, SafeMode.True);
                return dbConnection;
            }
        }
    }
}
