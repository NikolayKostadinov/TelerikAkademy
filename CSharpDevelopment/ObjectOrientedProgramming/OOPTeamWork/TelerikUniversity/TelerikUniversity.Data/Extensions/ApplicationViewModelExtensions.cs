using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Linq;
using TelerikUniversity.Data.Exceptions;

namespace TelerikUniversity.Data.Extensions
{
    static class ApplicationViewModelExtensions
    {
        public static IQueryable<T> LoadData<T>(this ApplicationViewModel source)
        {
            IQueryable<T> result = null;
            try
            {
                result = Configuration.db.GetCollection<T>(typeof(T).Name).AsQueryable();
            }
            catch (MongoConnectionException ex)
            {
                throw new DataBaseConnectionException("Cannot access database. Please try again later");
            }
            return result;
        }

        public static SafeModeResult SaveData<T>(this ApplicationViewModel source, T value)
        {
            SafeModeResult result = new SafeModeResult();
            try
            {
                result = Configuration.db.GetCollection<T>(typeof(T).Name).Save(value, SafeMode.True);
            }
            catch (MongoConnectionException ex)
            {
                throw new DataBaseConnectionException("Cannot access database. Please try again later");
            }
            return result;
        }
    }
}
