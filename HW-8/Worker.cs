namespace HW8
{
    public struct Worker
    {
        public int id;
        public string secondName;
        public string firstName;
        public int age;
        public int department;
        public int salary;

        public Worker(int id, string firstName, string secondName, int age, int department, int salary)
        {
            this.firstName = firstName;
            this.secondName = secondName;
            this.age = age;
            this.id = id;
            this.department = department;
            this.salary = salary;
        }

        public string PrintWorkers()
        {
            return $"{this.firstName,-10} {this.secondName,-10} {this.age,-10} " +
                   $"{this.id,-10} {this.department,-10} {this.salary,-10}";
        }
    }
}