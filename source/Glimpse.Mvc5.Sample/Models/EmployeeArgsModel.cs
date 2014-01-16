namespace Glimpse.Mvc5.Sample.Models
{
    public class EmployeeArgsModel
    {
        public int EmployeeID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int RoleID { get; set; }

        // Instead of using the above Properties, you could use an Employee, but the would have to change
        //public Employee Employee { get; set; }
        
        public string ReasonForEdit { get; set; }
    }
}