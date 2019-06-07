using EmployeeTraker.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeTracker.WebApplication.Models
{
    public class EmployeeViewModel
    {
        public IEnumerable<EmployeeInformation> EmployeesInformation { get; set; }
    }
}