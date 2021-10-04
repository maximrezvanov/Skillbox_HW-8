using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.IO;

namespace HW8
{
    public class DataHandler
    {
        public List<Department> departmentsList = new List<Department>();
        public List<Worker> workersList = new List<Worker>();
        public string[] workersTitles = new string[]{"Id", "FirstName", "SecondName", "Age", "Salary", "Depatrment"};
        public string[] departmentTitles = new []{"Name", "DateOfCreation", "Workers number"};
        private string json;
        private XmlSerializer xmlSerializer;
        public void AddWorker(int id, string firstName, string secondName, int age, int departmentNum, int salary)
        {
           departmentsList[departmentNum - 1].workers.Add(new Worker(id, firstName, secondName, age, departmentNum, salary));
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

        public void EditWorkers(int id, string firstName, string secondName, int age, int department, int salary)
        {
            Worker newWorker = new Worker();
            newWorker.age = age;
            newWorker.firstName = firstName;
            newWorker.secondName = secondName;
            newWorker.department = department;
            newWorker.salary = salary;
            newWorker.id = id;
            
            for (int i = 0; i < departmentsList.Count; i++)
            {
                for (int j = 0; j < departmentsList[i].workers.Count; j++)
                {

                    if (departmentsList[i].workers[j].id == id)
                    {
                        departmentsList[i].workers[j] = newWorker;
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
        
        public void EditDepartment(string departmentName, DateTime dateOfCreation, int departmentNum)
        {
            Department newDepartment = new Department();
            newDepartment.departmentName = departmentName;
            newDepartment.dateOfCreation = dateOfCreation.ToString();
            newDepartment.workers = departmentsList[departmentNum - 1].workers;
            departmentsList[departmentNum - 1] = newDepartment;
        }

        public void PrintWorkers()
        {
            Console.WriteLine($"{workersTitles[0], -10} {workersTitles[1], 10} {workersTitles[2], 10} {workersTitles[3], 10}" +
                              $"{workersTitles[4], 10} {workersTitles[5], 10}");

            for (int i = 0; i < departmentsList.Count; i++)
            {
                for (int j = 0; j < departmentsList[i].workers.Count; j++)
                {
                    Console.WriteLine($"{departmentsList[i].workers[j].id, -10} {departmentsList[i].workers[j].firstName, 10}" +
                                      $"{departmentsList[i].workers[j].secondName, 10} {departmentsList[i].workers[j].age, 10}" +
                                      $"{departmentsList[i].workers[j].salary, 10} {departmentsList[i].workers[j].department, 10}");
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
            Console.WriteLine($" {departmentTitles[0], 10} {departmentTitles[1], 15} {departmentTitles[2], 10}");
            foreach (var dep in departmentsList)
            {
                ++num;
                Console.WriteLine($"{num} " + dep.PrintDepartment() + $"{dep.workers.Count, 10}");
            }
        }

        public void SerializeJson(string path)
        {
            json = JsonConvert.SerializeObject(departmentsList);
            File.WriteAllText(path, json);
        }

        public void DeserializeJson(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("file not found");
                Console.ReadLine();
                return;
            }
            departmentsList.Clear();
            json = File.ReadAllText(path);
            departmentsList = JsonConvert.DeserializeObject<List<Department>>(json);
        }

        public void SerializeXml(string path)
        {
            xmlSerializer = new XmlSerializer(typeof(List<Department>));
            using (StreamWriter streamWriter = new StreamWriter(path, false))
            {
                xmlSerializer.Serialize(streamWriter, departmentsList);
            }
        }

        public void DeserializeXml(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("File not found");
                Console.ReadLine();
            }

            using (StreamReader streamReader = new StreamReader(path))
            {
                xmlSerializer = new XmlSerializer(typeof(List<Department>));
                departmentsList = (List<Department>) xmlSerializer.Deserialize(streamReader);
            }
        }
    }
}