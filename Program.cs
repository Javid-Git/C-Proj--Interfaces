using System;
using TemaProject.Services;
using TemaProject.Models;

namespace TemaProject
{
    class Program
    {
        static void Main(string[] args)
        {
            HumanResourceManager newhum = new HumanResourceManager();
            do
            {
                Console.WriteLine("*****MENU*****");
                Console.WriteLine("1.Departameantlerin siyahisini gostermek");
                Console.WriteLine("2.Departamenet yaratmaq");
                Console.WriteLine("3.Departmanetde deyisiklik etmek");
                Console.WriteLine("4.Iscilerin siyahisini gostermek");
                Console.WriteLine("5.Departamentdeki iscilerin siyahisini gostermrek");
                Console.WriteLine("6.Isci elave etmek");
                Console.WriteLine("7.Isci uzerinde deyisiklik etmek");
                Console.WriteLine("8.Departamentden isci silinmesi");
                Console.WriteLine("Verilnelerden birisini secmek ucun qbagindaki reqemi daxil edin!");
                byte choose = byte.Parse(Console.ReadLine());

                Console.Clear();
                switch (choose)
                {
                    case 1:
                        GetDepartments(ref newhum);
                        break;
                    case 2:
                        AddDepartment(ref newhum);
                        break;
                    case 3:
                        EditDepartment(ref newhum);
                        break;
                    case 4:
                        GetEmployees(ref newhum);
                        break;
                    case 5:
                        GetDepEmployees(ref newhum);
                        break;
                    case 6:
                        AddEmployee(ref newhum);
                        break;
                    case 7:
                        EditEmployee(ref newhum);
                        break;
                    case 8:
                        RemoveEmployee(ref newhum);
                        break;
                    default:
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Verilen reqemlerden secin!"); 
                        Console.ResetColor();

                        break;
                } 
           
            } while (true);
            static void GetDepartments(ref HumanResourceManager newhum)
            {
                if (newhum.Departments.Length>0)
                {
                    newhum.GetDepartments();
                    return;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Evvelce departament elave etmelisiniz!");
                    Console.ResetColor();
                }
            }
            static void AddDepartment(ref HumanResourceManager newhum)
            {
                Console.WriteLine("Departamentin adi:");
                string name = Console.ReadLine();
                Console.WriteLine("Departamentin maksimal isci sayisi:");
                int empnum = int.Parse(Console.ReadLine());
                Console.WriteLine("Departamentdeki minimal maas:");
                double minwage = double.Parse(Console.ReadLine());
                newhum.AddDepartment(name, empnum, minwage);
            }
            static void EditDepartment(ref HumanResourceManager newhum)
            {
                if (newhum.Departments.Length > 0)
                {
                    Console.WriteLine("Deyismek istediyiniz departamentin adini yazin!");
                    string depname = Console.ReadLine();
                    if (!String.IsNullOrWhiteSpace(depname))
                    {
                        Console.WriteLine("Yeni adi daxil edin!");
                        string newdepname = Console.ReadLine();

                        newhum.EditDepartaments(depname, newdepname);
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Bu adla departament yoxdur!");
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Evvelce departamnet elave edin!");
                    Console.ResetColor();
                }
                
            }
            static void GetEmployees(ref HumanResourceManager newhum)
            {
                int count = 0;
                if (newhum.Departments.Length>0)
                {
                    foreach (Department department in newhum.Departments)
                    {
                        if (department.Employees.Length>0)
                        {
                            if (count == 0)
                            {
                                Console.WriteLine("Iscilerin siyahisi\n\n");
                            }
                            foreach (Employee item in department.Employees)
                            {
                                Console.WriteLine($"{item}\n---------------------------");
                            }
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Evvelce isci elave edin!");
                            Console.ResetColor();
                        }
                        count++;
                        
                    }
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Evvelce isci elave edin!");
                    Console.ResetColor();
                }

            }
            static void GetDepEmployees(ref HumanResourceManager newhum)
            {
                //int count = 0;
                if (newhum.Departments.Length > 0)
                {
                    Console.WriteLine("Hansi departamentin iscilerini gormek isteyirsiniz?");
                    string depname = Console.ReadLine();
                    foreach (Department department in newhum.Departments)
                    {
                        if (depname.ToUpper() == department.Name)
                        {
                            if (department.Employees.Length > 0)
                            {
                                foreach (Employee item in department.Employees)
                                {
                                    Console.WriteLine(item);
                                }
                                return;
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("Evvelce isci elave edin!");
                                Console.ResetColor();
                                return;
                            }
                        }
                        //count++;
                        //if (count > newhum.Departments.Length-1)
                        //{

                        //}
                    }
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Bu adla departament yoxdur!");
                    Console.ResetColor();
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Evvelce departament elave etmelisiniz!");
                    Console.ResetColor();
                }
                
            }
            static void AddEmployee(ref HumanResourceManager newhum)
            {
                if (newhum.Departments.Length > 0)
                {
                    Console.WriteLine("Hansi departamente isci elave etmek isteyirsiniz?");
                    string depname = Console.ReadLine();
                    Console.WriteLine("Iscinin Ad ve Soyadini daxil edin!");
                    string fullname = Console.ReadLine();
                    Console.WriteLine("Iscinin vezifesini daxil edin!");
                    string position = Console.ReadLine();
                    Console.WriteLine("Iscinin maasini daxil edin!");
                    double maas = double.Parse(Console.ReadLine());


                    newhum.AddEmployee(depname.ToUpper(), fullname, maas, position);
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkYellow;

                    Console.WriteLine("Evvel departament elave edin!");
                    Console.ResetColor();
                }
            }
            static void EditEmployee(ref HumanResourceManager newhum)
            {
                int count = 0;
                if (newhum.Departments.Length > 0)
                {
                    foreach (Department item in newhum.Departments)
                    {
                        if (item.Employees.Length>0)
                        {
                            Console.WriteLine("Iscinin nomresini daxil edin!");
                            string empno = Console.ReadLine();
                            foreach (Employee employee in item.Employees)
                            {
                                if (employee.No == empno)
                                {
                                    Console.WriteLine("Iscinin Ad ve Soyadini daxil edin!");
                                    string fullname = Console.ReadLine();

                                    Console.WriteLine("Iscinin vezifesini daxil edin!");
                                    string position = Console.ReadLine();

                                    Console.WriteLine("Iscinin maasini daxil edin!");
                                    double salary = double.Parse(Console.ReadLine());

                                    newhum.EditEmploye(empno, fullname, salary, position);
                                }
                                count++;
                                if (count == item.Employees.Length)
                                {
                                    Console.BackgroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("Bu nomreli isci tapilmadi!");
                                    Console.ResetColor();
                                }   
                            }
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Evvelce isci elave edin!");
                            Console.ResetColor();
                        }
                    }
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Evvel departament elave edin!");
                    Console.ResetColor();
                }
            }
            static void RemoveEmployee(ref HumanResourceManager newhum)
            {
                if (newhum.Departments.Length > 0)
                {
                    Console.WriteLine("Iscilerin siyahisi:\n\n");
                    foreach (Department item in newhum.Departments)
                    {
                        if (item.Employees.Length > 0)
                        {
                            foreach (Employee employee in item.Employees)
                            {
                                Console.WriteLine(employee);
                            }

                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Evvelce isci elave edin!");
                            Console.ResetColor();
                            break;
                        }
                    }
                    Console.WriteLine("Iscinin nomresini daxil edin!");
                    string empno = Console.ReadLine();
                    newhum.RemoveEmployee(empno);
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Evvelce departament elave edin!");
                    Console.ResetColor();
                } 
            }
        }
    }
}
