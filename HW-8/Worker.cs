namespace HW8
{
    public struct Worker
    {
        public int id;
        public string secondName;
        public string firstName;
        public int age;
        public Department department;
        public int salary;

        public Worker(int id, string firstName, string secondName, int age, Department department, int salary)
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
            return $"{this.firstName,-10}/t {this.secondName,-10}/t {this.age,-10}/t " +
                   $"{this.id,-10}/t {this.department,-10}/t {this.salary,-10}";
        }
    }
}