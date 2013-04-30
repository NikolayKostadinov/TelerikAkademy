using System;
using System.Collections.Generic;
using System.Linq;
using TelerikUniversity.Data.Extensions;
using TelerikUniversity.Data.Library;

namespace TelerikUniversity.Data
{
    public class DataBase
    {
        private List<CityName> cities = new List<CityName>();
        public List<CityName> Cities
        {
            get 
            {
                if (this.cities.Count == 0)
                {
                    this.cities = AppCache.AppViewModel.LoadData<CityName>().ToList();
                    if (this.cities.Count == 0)
                    {
                        var result = Helpers.LoadFile(@"../../../Resources/cityNames.txt");
                        result.ForEach(r =>
                            {
                                CityName cn = new CityName() { Name = r };
                                AppCache.SaveData(cn);
                                this.cities.Add(cn);
                            });
                    }
                }
                return cities;
            }
            set { this.cities = value; }
        } 

        private List<StudentName> studentNames = new List<StudentName>();
        public List<StudentName> StudentNames
        {
            get
            {
                if (this.studentNames.Count == 0)
                {
                    this.studentNames = AppCache.AppViewModel.LoadData<StudentName>().ToList();
                    if (this.studentNames.Count == 0)
                    {
                        var result = Helpers.LoadFile(@"../../../Resources/studentNames.txt");
                        result.ForEach(r =>
                        {
                            StudentName sn = new StudentName() { Name = r };
                            AppCache.SaveData(sn);
                            this.studentNames.Add(sn);
                        });
                    }
                }
                return studentNames;
            }
            set { this.studentNames = value; }
        }
    }
}