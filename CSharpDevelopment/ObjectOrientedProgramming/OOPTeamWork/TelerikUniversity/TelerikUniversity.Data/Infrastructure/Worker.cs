using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikUniversity.Data.Enumerators;

namespace TelerikUniversity.Data.Infrastructure
{
    abstract class Worker
    {
        private DepartmentType department;

        public DepartmentType Department 
        {
            get { return this.department; }
            set { this.department = value; } 
        }

        public Worker(DepartmentType department)
        {
            this.Department = department;
        }

    }
}
