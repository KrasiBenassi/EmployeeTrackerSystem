using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeTracker.WebApplication.Models
{
    public class SubscriptionResponse
    {
        public string Token { get; set; }

        public DateTime Expires { get; set; }
    }
}