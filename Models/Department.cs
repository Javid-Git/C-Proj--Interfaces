using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemaProject.Models
{
    class Department
    {
        private string _name;
        public string Name 
        {
            get => _name;
            set
            {
                while (value.Length <= 2)
                {
                    Console.WriteLine("Ad 2 herfden artiq olmalidir!");
                    value = Console.ReadLine();
                }
                value = value.Replace(" ", String.Empty);
                _name = value;

                //bool check = false;
                //while (check)
                //{
                //    if (value.Length > 2)
                //    {
                //        _name = value;
                //        check = true;
                //    }
                //    else
                //    {
                //        Console.WriteLine("Ad 2 herfden artiq olmalidir!");
                //        value = Console.ReadLine();
                //    }
                //}
                
            }
        }
        private int _workerLimit;
        public int WorkerLimit 
        {
            get => _workerLimit;
            set
            {
                while (value <= 1)
                {
                    Console.WriteLine("Departamentdeki isci sayi 1 den artiq olmalidir!");
                    value = int.Parse(Console.ReadLine());
                }
                _workerLimit = value;

                //bool check = false;
                //while (check)
                //{
                //    if (value > 1)
                //    {
                //        _workerLimit = value;
                //        check = true;
                //    }
                //    else
                //    {
                //        Console.WriteLine("1 den artiq olmalidir!");
                //        value = int.Parse(Console.ReadLine());
                //    }
                //}
                
            }
        }
        private double _salaryLimit;
        public double SalaryLimit 
        {
            get => _salaryLimit;
            set
            {
                while (value <= 250)
                {
                    Console.WriteLine("Maas 250 AZN-den artiq olmalidir!");
                    value = int.Parse(Console.ReadLine());
                }
                _salaryLimit = value;
            }
        }
        public Employee[] Employees;

        public Department(string name, int workerlimit, double salarylimit)
        {
            Employees = new Employee[0];
            Name = name.ToUpper();
            WorkerLimit = workerlimit;
            SalaryLimit = salarylimit;
        }
        public double CalcSalaryAverage()
        {
            double average = 0;
            foreach (Employee employee in Employees)
            {
                average += employee.Salary;
            }
            average = average / Employees.Length;
            return average;
        }

        public void AddEmployee(Employee empl)
        {
            if (Employees.Length<_workerLimit)
            {
                Array.Resize(ref Employees, Employees.Length + 1);
                Employees[Employees.Length - 1] = empl;
                return;
            }
            Console.WriteLine("Departamentde yer yoxdur!");
        }

        public override string ToString()
        {
            return $"Departament adi: {_name}\nMaksimum isci sayi: {_workerLimit}\nMinimal emek haqqi: {_salaryLimit}";
        }

    }
}
