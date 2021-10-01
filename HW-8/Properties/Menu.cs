using System;

namespace HW8.Properties
{
    public class Menu
    {
        bool isShowMenu = true;
        string title, firstName, secondName, department;
        int input, salary, age, id, departmentNum;
        DataHandler dataHandler = new DataHandler();
        private DateTime dateTime = new DateTime(2022, 2, 22); 
        
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
                        while (isShowMenu)
                        {
                            AddData();
                        }
                        break;
                    // case 2:
                    //     while (isShowMenu)
                    //     {
                    //         EditData();
                    //     }
                    //     break;
                    // case 3:
                    //     while (isShowMenu)
                    //     {
                    //         SortData();
                    //     }
                    //     break;
                    // case 4:
                    //     while (isShowMenu)
                    //     {
                    //         RemoteData();
                    //     }
                    //     break;
                    // case 5:
                    //     while (isShowMenu)
                    //     {
                    //         PrintData();
                    //     }
                    //     break;
                    // case 6:
                    //     while (isShowMenu)
                    //     {
                    //         LoadData();
                    //     }
                    //     break;
                    // case 7:
                    //     while (isShowMenu)
                    //     {
                    //         SaveData();
                    //     }
                    //     break;
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
                    // isShowMenu = false;
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
                    isShowMenu = false;
                    Console.Clear();
                    if (dataHandler.departmentsList.Count > 0)
                    {
                        Console.WriteLine("Enter first name:");
                        firstName = Console.ReadLine();
                        Console.WriteLine("Enter second name:");
                        secondName = Console.ReadLine();
                        Console.WriteLine("Enter age worker:");
                        age = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter worker id:");
                        id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter worker salary:");
                        CheckInput(ref salary);
                        Console.WriteLine("Enter department number:");
                        int num = int.Parse(Console.ReadLine());
                        if (num <= 0 || num < dataHandler.departmentsList.Count - 1)
                        {
                            Console.WriteLine("Wrong input. Enter number:");
                            num = int.Parse(Console.ReadLine());
                        }
                        departmentNum = num;
                    }
                    else
                    {
                        Console.WriteLine("First you have to add a department");
                    }
                    dataHandler.AddWorker(id, firstName, secondName, age, departmentNum, salary);
                    Console.Clear();
                    dataHandler.PrintDepartment();
                    Console.WriteLine();
                    dataHandler.PrintWorkers();
                    Console.ReadLine();
                    break;
            }
        }
    }
}