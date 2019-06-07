using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTraker.DataLayer
{
    public class EmployeeInformation
    {
        public EmployeeInformation(int id, int employeeId, DateTime arrivalDateTime)
        {
            Id = id;
            EmployeeId = employeeId;
            ArrivalDateTime = arrivalDateTime;
        }

        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public DateTime ArrivalDateTime { get; set; }
    }
}
