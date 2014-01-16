using System.Linq;
using System.Web.Mvc;
using Glimpse.Mvc5.Sample.BLL;
using Glimpse.Mvc5.Sample.Models;
using Glimpse.Mvc5.Sample.ViewModels;

namespace Glimpse.Mvc5.Sample.Controllers
{
    public class EmployeeController : Controller
    {

        public ActionResult Index()
        {
            var employees = FakeData.Employees;
            return View(employees);
        }

        public ActionResult Create()
        {
            var employeeViewModel = new EmployeeViewModel();
            return View(employeeViewModel);
        }

        [HttpPost]
        public ActionResult Create(EmployeeViewModel employeeViewModel)
        {
            try
            {
                FakeData.Employees.Add(employeeViewModel.Employee);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int employeeID)
        {
            var employee = FakeData.Employees.FirstOrDefault(e => e.EmployeeID == employeeID);
            var employeeViewModel = new EmployeeViewModel(employee);
            return View(employeeViewModel);
        }

        [HttpPost]
        //public ActionResult Edit(FormCollection employeeArgsModel) // use a form collection to see the naming of the parameters passed to the method
        public ActionResult Edit(EmployeeArgsModel employeeArgsModel, string someOtherArgument)
        {
            try
            {
                var employee = FakeData.Employees.FirstOrDefault(e => e.EmployeeID == employeeArgsModel.EmployeeID);
                employee.Firstname = employeeArgsModel.Firstname;
                employee.Lastname = employeeArgsModel.Lastname;
                employee.RoleID = employeeArgsModel.RoleID;

                // to something the the ReasonForEdit and someOtherArgument

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Details(int employeeID = 0)
        {
            var employee = FakeData.Employees.FirstOrDefault(e => e.EmployeeID == employeeID);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }


        public ActionResult Delete(int employeeID)
        {
            var employee = FakeData.Employees.FirstOrDefault(e => e.EmployeeID == employeeID);
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int employeeID)
        {
            try
            {
                var employee = FakeData.Employees.FirstOrDefault(e => e.EmployeeID == employeeID);
                FakeData.Employees.Remove(employee);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
