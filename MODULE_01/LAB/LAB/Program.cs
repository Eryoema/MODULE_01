using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB
{
    public class Employee
    {
        public string Name { get; set; }
        public int EmployeeId { get; set; }
        public string Position { get; set; }

        public Employee(string name, int employeeId, string position)
        {
            Name = name;
            EmployeeId = employeeId;
            Position = position;
        }

        public virtual decimal CalculateSalary()
        {
            return 0;
        }

        public virtual void DisplaySalary()
        {
            Console.WriteLine($"{Name} ({Position}): зарплата не рассчитана.");
        }
    }

    public class Worker : Employee
    {
        public decimal HourlyRate { get; set; }
        public int HoursWorked { get; set; }

        public Worker(string name, int employeeId, string position, decimal hourlyRate, int hoursWorked)
            : base(name, employeeId, position)
        {
            HourlyRate = hourlyRate;
            HoursWorked = hoursWorked;
        }

        public override decimal CalculateSalary()
        {
            return HourlyRate * HoursWorked;
        }

        public override void DisplaySalary()
        {
            Console.WriteLine($"{Name} ({Position}): зарплата составляет {CalculateSalary()}.");
        }
    }

    public class Manager : Employee
    {
        public decimal FixedSalary { get; set; }
        public decimal Bonus { get; set; }

        public Manager(string name, int employeeId, string position, decimal fixedSalary, decimal bonus)
            : base(name, employeeId, position)
        {
            FixedSalary = fixedSalary;
            Bonus = bonus;
        }

        public override decimal CalculateSalary()
        {
            return FixedSalary + Bonus;
        }

        public override void DisplaySalary()
        {
            Console.WriteLine($"{Name} ({Position}): зарплата составляет {CalculateSalary()}.");
        }
    }

    public class EmployeeManagementSystem
    {
        public List<Employee> Employees { get; set; } = new List<Employee>();

        public void AddEmployee(Employee employee)
        {
            Employees.Add(employee);
            Console.WriteLine($"{employee.Name} добавлен(а) в систему.");
        }

        public void DisplayAllSalaries()
        {
            foreach (var employee in Employees)
            {
                employee.DisplaySalary();
            }
        }
    }

    public class Program
    {
        public static void Main()
        {
            var worker1 = new Worker("Максат Бакижанов", 1, "Рабочий", 20m, 160);
            var worker2 = new Worker("Асия Закирова", 2, "Рабочий", 25m, 150);
            var manager1 = new Manager("Жанибек Мергенбай", 3, "Менеджер", 50000m, 10000m);
            var manager2 = new Manager("Ернар Калдарбек", 4, "Менеджер", 60000m, 15000m);

            var system = new EmployeeManagementSystem();

            system.AddEmployee(worker1);
            system.AddEmployee(worker2);
            system.AddEmployee(manager1);
            system.AddEmployee(manager2);

            system.DisplayAllSalaries();
        }
    }
}
