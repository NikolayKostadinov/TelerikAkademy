using System;
using System.Collections.Generic;
using System.Linq;
using TelerikUniversity.Data.Exceptions;
using TelerikUniversity.Data.Library;
using TelerikUniversity.Data.Extensions;
using MongoDB.Driver;

namespace TelerikUniversity.Data
{
    public static class AppCache
    {
        public static ApplicationViewModel AppViewModel { get; set; }
        static AppCache()
        {
            AppViewModel = new ApplicationViewModel();
        }

        private static List<Student> studentList = new List<Student>();
        public static List<Student> StudentList
        {
            get
            {
                if (studentList.Count == 0)
                {
                    try
                    {
                        studentList = AppCache.AppViewModel.LoadData<Student>().ToList();
                    }
                    catch (MongoConnectionException ex)
                    {
                        throw new DataBaseConnectionException("Cannot access database. Please try again later");
                    }
                }
                return studentList;
            }
            set { studentList = value; }
        }

        public static SafeModeResult SaveData<T>(T value)
        {
            SafeModeResult result = new SafeModeResult();
            try
            {
                result = AppCache.AppViewModel.SaveData(value);
            }
            catch (MongoConnectionException ex)
            {
                throw new DataBaseConnectionException("Cannot access database. Please try again later");
            }
            if (result.Ok)
            {
                if (value is Student)
                    AppCache.StudentList.Add(value as Student);
            }
            return result;
        }
    }
}
