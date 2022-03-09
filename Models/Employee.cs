using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemaProject.Models
{
    class Employee
    {
        private static int _count = 1000;
        private string _no;
        public string No
        {
            get => _no;
            set
            {
                _no = value.ToUpper();
            }
        }
        public string FullName { get; set; }
        public double Salary { get; set; }
        public string Position;
        public string DepartmentName { get; set; }

        public Employee(string fullname, double salary, string position, string departmentname)
        {
            FullName = fullname.ToUpper().Trim();
            Salary = salary;
            Position = position.Replace(" ", String.Empty);
            DepartmentName = departmentname.Trim().ToUpper().Replace(" ", String.Empty);
            _count++;
            No = $"{DepartmentName.Substring(0,2)}{_count}";
        }

        public override string ToString()
        {
            return $"Nomre: {No}\nAd ve Soyad: {FullName}\nDepartament: {DepartmentName}\nVezife: {Position}\nEmek haqqi: {Salary}\n";
        }
    }

}
