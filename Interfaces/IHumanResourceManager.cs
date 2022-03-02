using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemaProject.Models;

namespace TemaProject.Interfaces
{
    interface IHumanResourceManager
    {
        Department[] Departments { get; }

        public void AddDepartment(string name, int workerlimit, double salarylimit);
        public void GetDepartments();
        public void EditDepartaments(string name, string newname);
        public void AddEmployee(string depname, string fullname, double salary, string position);
        public void RemoveEmployee(string No);
        public void EditEmploye(string No, string fullname, double salary, string position);
    }
}
