﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemaProject.Interfaces;
using TemaProject.Models;

namespace TemaProject.Services
{
    class HumanResourceManager : IHumanResourceManager
    {
        private Department[] _departments; 
        public Department[] Departments => _departments;

        public HumanResourceManager()
        {
            _departments = new Department[0];
        }

        public void AddDepartment(string name, int workerlimit, double salarylimit)
        {
            foreach (Department item in _departments)
            {
                while (name.ToUpper() == item.Name)
                {
                    Console.WriteLine("Bu adla departament artiq var, basqasini daxil edin!");
                    name = Console.ReadLine();
                }
            }
            Array.Resize(ref _departments, _departments.Length + 1);
            _departments[_departments.Length -1] = new Department(name, workerlimit, salarylimit);
        }

        public void AddEmployee(string depname, string fullname, double salary, string position)
        {
            Department department = null;
            foreach (Department item in _departments)
            {
                if (item.Name == depname.Trim().ToUpper())
                {
                    department = item;
                }
                while (salary < item.SalaryLimit)
                {
                    Console.WriteLine($"Emek haqqi {item.SalaryLimit}-den eksik olmali deyil");
                    salary = double.Parse(Console.ReadLine());
                }
            }
            if (department != null)
            {
                Employee newemp = new Employee(fullname, salary, position, depname);

                department.AddEmployee(newemp);
                return;
            }
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Yazdiginiz departament tapilamdi!");
            Console.ResetColor();
        }

        public void EditDepartaments(string depname, string newname)
        {
            foreach (Department item in _departments)
            {
                while (newname.ToUpper() == item.Name)
                {
                    Console.WriteLine("Bu adla departament artiq var, basqasini daxil edin!");
                    newname = Console.ReadLine();
                }
                if (item.Name == depname.ToUpper())
                {
                    item.Name = newname.ToUpper();
                    foreach (Employee employee in item.Employees)
                    {
                        employee.DepartmentName = newname.ToUpper();
                        string newnew = $"{newname.ToUpper()[0]}{newname.ToUpper()[1]}{employee.No.Substring(2, 3)}";
                        employee.No = newnew;
                        
                    }
                    return;
                }
            }
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Bele adli departamenet yoxdur!");
            Console.ResetColor();
        }

        public void EditEmploye(string No, string fullname, double salary, string position)
        {
            foreach (Department department in _departments)
            {
                foreach (Employee empl in department.Employees)
                {
                    if (empl.No == No)
                    {
                        empl.FullName = fullname;
                        empl.Salary = salary;
                        empl.Position = position;
                        return;
                    }
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Bu nomreli isci tapilmadi!");
                    Console.ResetColor();
                }
            }
        }

        public void GetDepartments()
        {
            Console.WriteLine("Departamentlerin siyahisi:\n\n");
            foreach (Department department in _departments)
            {
                Console.WriteLine($"{department}\n---------------------------\n");

            }
        }

        public void RemoveEmployee(string No)
        {
            //int count = 0;
            foreach (Department department in _departments)
            {
                for (int i = 0; i < department.Employees.Length; i++)
                {
                    if (department.Employees[i].No == No.ToUpper())
                    {
                        department.Employees[i] = null;
                        department.Employees[i] = department.Employees[department.Employees.Length - 1];
                        Array.Resize(ref department.Employees, department.Employees.Length - 1);
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Silindi!");
                        Console.ResetColor();
                        return;
                    }
                }
            //    count++;
                
            //}
            //if (count == _departments.Length)
            //{
            //    Console.BackgroundColor = ConsoleColor.DarkRed;
            //    Console.WriteLine("Bu nomreli isci tapilmadi!");
            //    Console.ResetColor();
            }
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Bu nomreli isci tapilmadi!");
            Console.ResetColor();
        }
    }
}
