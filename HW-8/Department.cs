using System;
using System.Collections.Generic;

namespace HW8
{
    public struct Department
    {
        public string departmentName;
        public string dateOfCreation;
        public List<Worker> workers;
        
        public Department(string departmentName, string dateOfCreation)
        {
            this.departmentName = departmentName;
            this.dateOfCreation = dateOfCreation;
            this.workers = new List<Worker>();
        }
        
        public string PrintDepartment()
        {
            return $"{this.departmentName, -10} {this.dateOfCreation, -10}";
        }
    }
}