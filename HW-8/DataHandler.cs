using System;
using System.Collections.Generic;

namespace HW8
{
    public class DataHandler
    {
        private Worker worker;
        private Department department;
        public List<Department> departmentsList = new List<Department>();
        public List<Worker> workersList = new List<Worker>();
        public string workersTitle;
        public string departmentTitle;

        public void AddWorker(int id, string firstName, string secondName, int age, Department department, int salary)
        {
            workersList.Add(new Worker(id, firstName, secondName, age, department, salary));
        }

        public void RemoveWorker(int idWorkers)
        {
            for (int i = 0; i < departmentsList.Count; i++)
            {
                for (int j = 0; j < departmentsList[i].workers.Count; j++)
                {
                    if (departmentsList[i].workers[j].id == idWorkers)
                    {
                        departmentsList[i].workers.Remove(departmentsList[i].workers[j]);
                    }
                }
            }
        }

        public void EditWorkers(int id, string firstName, string secondName, int age, Department department, int salary)
        {
            Worker worker = new Worker();
            worker.age = age;
            worker.firstName = firstName;
            worker.secondName = secondName;
            worker.department = department;
            worker.salary = salary;
            
            for (int i = 0; i < departmentsList.Count; i++)
            {
                for (int j = 0; j < departmentsList[i].workers.Count; j++)
                {
                    if (departmentsList[i].workers[j].id == id)
                    {
                        departmentsList[i].workers[j] = worker;
                    }
                }
            }
        }

        public void AddDepartment(string departmentName, DateTime dateOfCreation)
        {
            departmentsList.Add(new Department(departmentName, dateOfCreation));
        }
        
        public void RemoteDepartment(int depNum)
        {
            departmentsList.Remove(departmentsList[depNum - 1]);
        }
        
        public void EditDepartment(string departmentName, DateTime dateOfCreation, int departmentNum)
        {
            Department newDepartment = new Department();
            newDepartment.departmentName = departmentName;
            newDepartment.dateOfCreation = dateOfCreation;
            newDepartment.workers = departmentsList[departmentNum - 1].workers;
            departmentsList[departmentNum - 1] = newDepartment;
        }
    }
}