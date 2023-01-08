using Lesson_3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.MVC.Lesson_3
{
    public class Work_3
    {
        public static void Run()
        {
            Random rnd = new Random();



            List<Person> people = new List<Person>//<string> {Иван,.....}  :)
            {
                new Person { Name="Иван"},
                new Person{ Name="Алексей"},
                new Person { Name="Андрей"},
                new Person { Name="Алексей"},
                new Person{ Name="Виктор"},
                new Person{ Name="Виталий"},
                new Person{ Name="Олег"},
                new Person{ Name="Игорь"},
                new Person{ Name="Илья"},
                new Person{Name="Владимир"}
            };

            //var prs = new Person();
            //Console.WriteLine(prs.From("Иван"));


            var employes = new Employee[10];

            for (int i = 0; i < employes.Length; i++)
            {
                if (i % 2 == 0)
                {
                    employes[i] = new FixedEmployee(
                        $"{people[i].Name}",
                        rnd.Next(1000, 5000));
                }
                else
                {
                    employes[i] = new TimeEmploye(
                        $"{people[i].Name}",
                        rnd.Next(1000, 5000),
                        (rnd.Next(25, 100))
                    );
                }

            }
            foreach (Employee item in employes)
            {

                Console.WriteLine($"{item.Name}, {item.CalulateSalary()} $");
            }


        }

    }
    public static class PersonBuilder
    {
        private static readonly Person person = new Person();

        public static Person Build()
        {
            if (string.IsNullOrEmpty(person.Name))
                throw new InvalidOperationException("Null Exeception \"To\"");

            return person;
        }


        public static Person From(this Person person, string address)
        {
            person.Name = address;
            return person;
        }
    }

    public abstract class Employee
    {
        public string Name { get; set; }


        public Employee(string name)
        {
            Name = name;
        }

        public abstract decimal CalulateSalary();
    }


    public class TimeEmploye : Employee
    {
        private decimal Salary { get; set; }
        public decimal HourRate { get; set; }
        public TimeEmploye(string Name, decimal salary, int hourRate) : base(Name)
        {
            Salary = salary;
            HourRate = hourRate;
        }
        public override decimal CalulateSalary()
        {
            return 20.8m * 8 * HourRate;
        }
    }


    public class FixedEmployee : Employee
    {
        private decimal Salary { get; set; }

        public FixedEmployee(string Name, decimal salary) : base(Name)
        {
            Salary = salary;
        }
        public override decimal CalulateSalary()
        {
            return Salary;
        }
    }

}

