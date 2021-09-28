using System;
using System.Collections.Generic;

namespace HW8
{
    public struct Department
    {
        public string departmentName;
        public DateTime dateOfCreation;
        public List<Worker> workers;
        
        public Department(string departmentName, DateTime dateOfCreation)
        {
            this.departmentName = departmentName;
            this.dateOfCreation = dateOfCreation;
            this.workers = new List<Worker>();
        }
        
        public string PrintDepartment()
        {
            return $"{this.departmentName,-10}/t {this.dateOfCreation,-10}/t";
        }
    }
}