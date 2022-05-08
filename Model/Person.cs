
using System;

namespace EmployeeApp.Model
{
    public class Person
    {
        public string firstName { get; private set; }
        public string middleName { get; private set; }
        public string secondName { get; private set; }
        public string department { get; private set; }
        public string position { get; private set; }
        public double? salary { get; private set; }
        public char? kpi { get; private set; }
        public Person() { }
        public Person(string firstName, string middleName, string secondName, string department, string position, double salary, char kpi)
            : this(firstName, middleName, secondName, department, position, salary)
        {
            this.kpi = kpi;
        }
        public Person(string firstName, string middleName, string secondName, string department, string position, double salary)
        {
            this.firstName = firstName;
            this.middleName = middleName;
            this.secondName = secondName;
            this.department = department;
            this.position = position;
            this.salary = salary;
        }
        public Person(string firstName, string middleName, string secondName, string position, double salary, char kpi)
        {
            this.firstName = firstName;
            this.middleName = middleName;
            this.secondName = secondName;
            this.position = position;
            this.salary = salary;
            this.kpi = kpi;
        }
    }
    public class Employee : Person
    {
        public int id { get; private set; }
        public string fullName { get; private set; }
        public string phoneNumber { get; private set; }
        public string address { get; private set; }
        public double? premium { get; private set; }
        public Employee(string firstName,  string middleName, string lastName, string phoneNumber
                      , string address, string position, double salary, char kpi) : base(firstName, middleName
                                                                                       , lastName, position
                                                                                       , salary, kpi)
        {
            this.phoneNumber = phoneNumber;
            this.address = address;
        }
        public Employee(int id, string firstName, string middleName, string lastName
                       ,string phoneNumber, string address, string department
                       ,string position, double salary, char kpi) : base(firstName, middleName, lastName
                                                                       , department, position, salary, kpi)
        {
            this.id = id;
            this.phoneNumber = phoneNumber;
            this.address = address;
            fullName = $"{secondName} {firstName} {middleName}";

            switch (kpi)
            {
                case 'a':
                    premium = Math.Round(salary * 0.2, 2);
                    break;
                case 'b':
                    premium = Math.Round(salary * 0.3, 2);
                    break;
                case 'c':
                    premium = Math.Round(salary * 0.4, 2);
                    break;
                default:
                    break;
            }

        }
    }
}
