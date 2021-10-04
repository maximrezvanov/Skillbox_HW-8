using System;

namespace HW8.Properties
{
    public class Menu
    {
        bool isShowMenu = true;
        string title, firstName, secondName, department;
        int input, salary, age, id, departmentNum, num;
        DataHandler dataHandler = new DataHandler();
        private DateTime dateTime = new DateTime(2022, 2, 22); 
        string pathJson = "data.json";
        string pathXml = "data.xml";
        string savepathJson = "savedata.json";
        string savepathXml = "savedata.xml";
        public void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("Make a choice:");
                Console.WriteLine("Add data, press key 1");
                Console.WriteLine("Edit data, press key 2");
                Console.WriteLine("Sort data, press key 3");
                Console.WriteLine("Delete data, press key 4");
                Console.WriteLine("Print data, press key 5");
                Console.WriteLine("Load data, press key 6");
                Console.WriteLine("Save data, press key 7");
            
                CheckInput(ref input);
                switch (input)
                {
                    case 1:
                        isShowMenu = true;
                        while (isShowMenu)
                        {
                            AddData();
                        }
                        break;
                    case 2:
                        isShowMenu = true;
                        while (isShowMenu)
                        {
                            EditData();
                        }
                        break;
                    case 3:
                        isShowMenu = true;
                        while (isShowMenu)
                        {
                            SortData();
                        }
                        break;
                    case 4:
                        isShowMenu = true;
                        while (isShowMenu)
                        {
                            RemoteData();
                        }
                        break;
                    case 5:
                        isShowMenu = true;
                        while (isShowMenu)
                        {
                            PrintData();
                            isShowMenu = false;
                        }
                        break;
                    case 6:
                        isShowMenu = true;
                        while (isShowMenu)
                        {
                            LoadData();
                        }
                        break;
                    case 7:
                        isShowMenu = true;
                        while (isShowMenu)
                        {
                            SaveData();
                        }
                        break;
                } 
            }
        }
        private void CheckInput(ref int input)
        {
            while (!Int32.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Wrong input");
            }
        }

        private void CheckDateInput(ref DateTime dateTime)
        {
            while (!DateTime.TryParse(Console.ReadLine(), out dateTime))
            {
                Console.WriteLine("Wrong input, format MM/dd/yyyy)");
            }
        }
        
        private void AddData()
        {
            Console.Clear();
            Console.WriteLine("Make a choice:");
            Console.WriteLine("Add department, press key 1");
            Console.WriteLine("Add worker, press key 2");
            Console.WriteLine("Back, press key 0");

            CheckInput(ref input);

            switch (input)
            {
                case 1:
                    Console.WriteLine("Enter the name of the department");
                    title = Console.ReadLine();
                    Console.WriteLine("Enter date (MM/dd/yyyy)");
                    CheckDateInput(ref dateTime);
                    dataHandler.AddDepartment(title, dateTime.ToString("MM/dd/yyyy"));
                    Console.Clear();
                    Console.WriteLine(dataHandler.departmentsList.Count);
                    dataHandler.PrintDepartment();
                    Console.ReadLine();
                    break;
                case 2:
                    Console.Clear();
                    if (dataHandler.departmentsList.Count > 0)
                    {
                        Console.WriteLine("Enter first name:");
                        firstName = Console.ReadLine();
                        Console.WriteLine("Enter second name:");
                        secondName = Console.ReadLine();
                        Console.WriteLine("Enter age worker:");
                        CheckInput(ref age);  
                        Console.WriteLine("Enter worker id:");
                        CheckInput(ref id);
                        Console.WriteLine("Enter worker salary:");
                        CheckInput(ref salary);
                        Console.WriteLine("Enter department number:");
                        CheckInput(ref num);
                        if (num <= 0 || num < dataHandler.departmentsList.Count - 1)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Wrong input. Enter number:");
                            Console.ResetColor();
                            num = int.Parse(Console.ReadLine());
                        }
                        departmentNum = num;
                        dataHandler.AddWorker(id, firstName, secondName, age, departmentNum, salary);
                    }
                    else
                    {
                        Console.WriteLine("First you have to add a department");
                    }
                    Console.Clear();
                    dataHandler.PrintDepartment();
                    Console.WriteLine();
                    dataHandler.PrintWorkers();
                    Console.ReadLine();
                    break;
                case 0:
                    isShowMenu = false;
                    break;
            }
        }

        private void EditData()
        {
            Console.WriteLine("To edit departments press 1");
            Console.WriteLine("To edit workers press 2");
            Console.WriteLine("Back, press 0");

            CheckInput(ref input);

            switch (input)
            {
                case 1:
                    Console.Clear();
                    dataHandler.PrintDepartment();
                    Console.WriteLine();
                    Console.WriteLine("Enter department num");
                    CheckInput(ref num);
                    Console.WriteLine("Enter new date (MM/dd/yyyy)");
                    CheckDateInput(ref dateTime);
                    Console.WriteLine("Enter new department name:");
                    department = Console.ReadLine();
                    dataHandler.EditDepartment(department, dateTime, num);
                    Console.Clear();
                    dataHandler.PrintDepartment();
                    Console.ReadLine();
                    break;
                case 2:
                    Console.Clear();
                    dataHandler.PrintWorkers();
                    Console.WriteLine("Enter workers ID:");
                    CheckInput(ref num);
                    Console.WriteLine("Enter first name:");
                    firstName = Console.ReadLine();
                    Console.WriteLine("Enter second name:");
                    secondName = Console.ReadLine();
                    Console.WriteLine("Enter age:");
                    CheckInput(ref age);
                    Console.WriteLine("Enter salary:");
                    CheckInput(ref salary);
                    Console.WriteLine("Enter department number");
                    CheckInput(ref num);
                    dataHandler.EditWorkers(id, firstName, secondName, age, num, salary);
                    Console.Clear();
                    dataHandler.PrintWorkers();
                    Console.ReadLine();
                    break;
                
                case 0:
                    isShowMenu = false;
                    break;
            }
        }

        private void SortData()
        {
            Console.Clear();
            Console.WriteLine("Sort wrokers by:");
            Console.WriteLine("1 - second name");
            Console.WriteLine("2 - age");
            Console.WriteLine("3 - salary");
            Console.WriteLine("4 - id");
            Console.WriteLine("Back, press 0");
            
            CheckInput(ref input);

            switch (input)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                dataHandler.SortWorkers(input);
                Console.Clear();
                    break;
                case 0:
                    isShowMenu = false;
                    break;
            }
        }

        private void RemoteData()
        {
            Console.Clear();
            Console.WriteLine("Remote department, press 1");
            Console.WriteLine("Remote worker, press 2");
            
            CheckInput(ref input);

            switch (input)
            {
                case 1:
                    dataHandler.PrintDepartment();
                    Console.WriteLine();
                    Console.WriteLine("Enter department num");
                    CheckInput(ref num);
                    dataHandler.RemoteDepartment(num);
                    Console.Clear();
                    dataHandler.PrintDepartment();
                    Console.ReadLine();
                    break;
                case 2:
                    dataHandler.PrintWorkers();
                    Console.WriteLine();
                    Console.WriteLine("Enter worker ID");
                    CheckInput(ref id);
                    dataHandler.RemoveWorker(id);
                    Console.Clear();
                    dataHandler.PrintWorkers();
                    Console.ReadLine();
                    break;
                case 0:
                    isShowMenu = false;
                    break;
            }
        }

        private void PrintData()
        {
            if (dataHandler.departmentsList.Count > 0)
            {
                dataHandler.PrintDepartment();
                dataHandler.PrintWorkers(); 
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Department list is epmty");
                Console.ResetColor();
            }
        }

        private void SaveData()
        {
            Console.WriteLine("Make a choice save format:");
            Console.WriteLine("Json, press 1");
            Console.WriteLine("Xml, press 2");
            Console.WriteLine("Back, press 0");
            
            CheckInput(ref input);

            switch (input)
            {
                case 1:
                    dataHandler.SerializeJson(pathJson);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Successfully");
                    Console.ResetColor();
                    break;
                case 2:
                    dataHandler.SerializeXml(pathXml);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Successfully");
                    Console.ResetColor();
                    break;
                case 0:
                    isShowMenu = false;
                    break;
            }
        }

        private void LoadData()
        {
            Console.WriteLine("Make a choice load format:");
            Console.WriteLine("Json, press 1");
            Console.WriteLine("Xml, press 2");
            Console.WriteLine("Back, press 0");
            
            CheckInput(ref input);

            switch (input)
            {
                case 1:
                    dataHandler.DeserializeJson(pathJson);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Successfully");
                    Console.ResetColor();
                    break;
                case 2:
                    dataHandler.DeserializeXml(pathXml);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Successfully");
                    Console.ResetColor();
                    break;
                case 0:
                    isShowMenu = false;
                    break;
            }
        }
    }
}