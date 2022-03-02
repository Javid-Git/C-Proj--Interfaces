using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemaProject.Models
{
    class Employee
    {
        private int _count = 1000;

        public string No;
        public string FullName { get; set; }
        public double Salary { get; set; }
        public string Position;
        public string DepartmentName { get; set; }

        public Employee(string fullname, double salary, string position, string departmentname)
        {
            FullName = fullname.ToUpper();
            Salary = salary;
            Position = position;
            DepartmentName = departmentname.Trim().ToUpper();
            _count++;
            No = $"{DepartmentName[0]}{DepartmentName[1]}{_count}";
        }

        public override string ToString()
        {
            return $"Nomre: {No}\nAd ve Soyad: {FullName}\nDepartament: {DepartmentName}\nVezife: {Position}\nEmek haqqi: {Salary}\n";
        }
    }
    
}
