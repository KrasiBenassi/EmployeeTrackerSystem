using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeTracker.WebApplication.Models
{
    public class EmployeeInformationRequest
    {
        public int EmployeeId { get; set; }

        public DateTime When { get; set; }
    }
}