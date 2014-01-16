using System.Collections.Generic;
using System.Web.Mvc;
using Glimpse.Mvc5.Sample.BLL;

namespace Glimpse.Mvc5.Sample.ViewModels
{
    public class EmployeeViewModel
    {
        public EmployeeViewModel()
        {
            Employee = new Employee();
            Roles = PopulateRoles();
        }

        public EmployeeViewModel(Employee employee)
        {
            Employee = employee;
            Roles = PopulateRoles();
        }
        
        public Employee Employee { get; set; }
        public IEnumerable<SelectListItem> Roles { get; set; }

        private IEnumerable<SelectListItem> PopulateRoles()
        {
            return new SelectList(FakeData.Roles, "RoleID", "Description");
        }
    }
}