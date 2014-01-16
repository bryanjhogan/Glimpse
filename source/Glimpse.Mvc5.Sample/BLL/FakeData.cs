using System.Collections.Generic;

namespace Glimpse.Mvc5.Sample.BLL
{
    public class FakeData
    {
        public static List<Employee> Employees = new List<Employee>();
        public static List<Role> Roles  = new List<Role>();

        static FakeData()
        {
            Roles.Add(new Role {RoleID = 1, Description = "Junior Engineer"});
            Roles.Add(new Role {RoleID = 2, Description = "Senior Engineer"});
            Roles.Add(new Role {RoleID = 3, Description = "Lead Engineer"});

            Employees.Add(new Employee { EmployeeID = 1, Firstname = "John", Lastname = "Jones", RoleID = 1 });
            Employees.Add(new Employee { EmployeeID = 2, Firstname = "Steve", Lastname = "Smith", RoleID = 2 });
            Employees.Add(new Employee { EmployeeID = 3, Firstname = "Tim", Lastname = "Thompson", RoleID = 3 });
        }
    }
}