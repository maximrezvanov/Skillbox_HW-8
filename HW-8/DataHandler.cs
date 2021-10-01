using System;
using System.Collections.Generic;
using System.Linq;

namespace HW8
{
    public class DataHandler
    {
        public List<Department> departmentsList = new List<Department>();
        public List<Worker> workersList = new List<Worker>();
        public string[] workersTitles = new string[]{"Id", "FirstName", "SecondName", "Age", "Salary", "Depatrment"};
        public string[] departmentTitles = new []{"Name", "DateOfCreation", "Workers number"};

        public void AddWorker(int id, string firstName, string secondName, int age, int departmentNum, int salary)
        {
            workersList.Add(new Worker(id, firstName, secondName, age, departmentsList[departmentNum - 1], salary));
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

        public void SortWorkers(int num)
        {
            workersList = new List<Worker>();
            for (int i = 0; i < departmentsList.Count; i++)
            {
                for (int j = 0; j < departmentsList[i].workers.Count; j++)
                {
                    workersList.Add(departmentsList[i].workers[j]);
                }
            }

            switch (num)
            {
                case 1:
                    workersList = workersList.OrderBy(e => e.id)
                        .ThenBy(e => e.firstName)
                        .ThenBy(e => e.secondName)
                        .ThenBy(e => e.age)
                        .ThenBy(e => e.salary)
                        .ThenBy(e => e.department)
                        .ToList();
                    Console.Clear();
                    PrintSorteredWorkers();
                    Console.ReadLine();
                    break;
                case 2:
                    workersList = workersList.OrderBy(e => e.firstName)
                        .ThenBy(e => e.secondName)
                        .ThenBy(e => e.age)
                        .ThenBy(e => e.salary)
                        .ThenBy(e => e.department)
                        .ThenBy(e => e.id)
                        .ToList();
                    Console.Clear();
                    PrintSorteredWorkers();
                    Console.ReadLine();
                    break;
                case 3:
                    workersList = workersList.OrderBy(e => e.secondName)
                        .ThenBy(e => e.firstName)
                        .ThenBy(e => e.age)
                        .ThenBy(e => e.salary)
                        .ThenBy(e => e.department)
                        .ThenBy(e => e.id)
                        .ToList();
                    Console.Clear();
                    PrintSorteredWorkers();
                    Console.ReadLine();
                    break;
                case 4:
                    workersList = workersList.OrderBy(e => e.age)
                        .ThenBy(e => e.id)
                        .ThenBy(e => e.firstName)
                        .ThenBy(e => e.secondName)
                        .ThenBy(e => e.salary)
                        .ThenBy(e => e.department)
                        .ToList();
                    Console.Clear();
                    PrintSorteredWorkers();
                    Console.ReadLine();
                    break;
                case 5:
                    workersList = workersList.OrderBy(e => e.salary)
                        .ThenBy(e => e.id)
                        .ThenBy(e => e.firstName)
                        .ThenBy(e => e.secondName)
                        .ThenBy(e => e.age)
                        .ThenBy(e => e.department)
                        .ToList();
                    Console.Clear();
                    PrintSorteredWorkers();
                    Console.ReadLine();
                    break;
                case 6:
                    workersList = workersList.OrderBy(e => e.department)
                        .ThenBy(e => e.id)
                        .ThenBy(e => e.firstName)
                        .ThenBy(e => e.secondName)
                        .ThenBy(e => e.age)
                        .ThenBy(e => e.salary)
                        .ToList();
                    Console.Clear();
                    PrintSorteredWorkers();
                    Console.ReadLine();
                    break;
                default:
                    break;
            }
        }

        public void AddDepartment(string departmentName, string dateOfCreation)
        {
            departmentsList.Add(new Department(departmentName, dateOfCreation));
        }
        
        public void RemoteDepartment(int depNum)
        {
            departmentsList.Remove(departmentsList[depNum - 1]);
        }
        
        public void EditDepartment(string departmentName, string dateOfCreation, int departmentNum)
        {
            Department newDepartment = new Department();
            newDepartment.departmentName = departmentName;
            newDepartment.dateOfCreation = dateOfCreation;
            newDepartment.workers = departmentsList[departmentNum - 1].workers;
            departmentsList[departmentNum - 1] = newDepartment;
        }

        public void PrintWorkers()
        {
            Console.WriteLine($"{workersTitles[0], -10} {workersTitles[1], 10} {workersTitles[2], 10} {workersTitles[3], 10}" +
                              $"{workersTitles[4], 10} {workersTitles[5], 10}");

            Console.WriteLine("departmentsList.Count " + departmentsList.Count);
            for (int i = 0; i < departmentsList.Count; i++)
            {
                for (int j = 0; j < departmentsList[i].workers.Count; j++)
                {
                    Console.WriteLine($"{departmentsList[i].workers[j].id, 10} {departmentsList[i].workers[j].firstName, 10}" +
                                      $"{departmentsList[i].workers[j].secondName, 10} {departmentsList[i].workers[j].salary, 10}" +
                                      $"{departmentsList[i].workers[j].age, 10} {departmentsList[i].workers[j].department}");

                    Console.WriteLine($"{departmentsList[i].workers[j].PrintWorkers()}");
                    Console.WriteLine($"workersList - {departmentsList[i].workers[j].PrintWorkers()}");

                    
                }
            }
        }
        public void PrintSorteredWorkers()
        {
            Console.WriteLine($"{workersTitles[0], 10} {workersTitles[1], 10} {workersTitles[2], 10} {workersTitles[3], 10}" +
                              $"{workersTitles[4], 10} {workersTitles[5], 10}");

            for (int i = 0; i < workersList.Count; i++)
            {
                Console.WriteLine($"{workersList[i].id, 10} {workersList[i].firstName, 10} {workersList[i].secondName, 10} " +
                                  $"{workersList[i].age, 10} {workersList[i].salary, 10} {workersList[i].department, 10}");
            }
            
        }

        public void PrintDepartment()
        {
            int num = 0;
            Console.WriteLine($"{departmentTitles[0], -2} {departmentTitles[1], 10} {departmentTitles[2], 10}");
            foreach (var dep in departmentsList)
            {
                ++num;
                Console.WriteLine($"{num} " + dep.PrintDepartment() + $"{dep.workers.Count, 10}");
            }

            // Console.WriteLine($"Departments number: {departmentsList.Count}");
        }
        
    }
}