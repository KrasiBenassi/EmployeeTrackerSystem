using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTraker.DataLayer
{
    public partial class EmployeeArrivalInformation
    {
        public static implicit operator EmployeeInformation(EmployeeArrivalInformation employeeArrivalInformation)
        {
            return new EmployeeInformation(
                employeeArrivalInformation.Id, 
                employeeArrivalInformation.EmployeeId,
                employeeArrivalInformation.ArrivalDateTime);
        }

        public static implicit operator EmployeeArrivalInformation(EmployeeInformation employeeInformation)
        {
            return new EmployeeArrivalInformation
            {
                Id = employeeInformation.Id,
                EmployeeId = employeeInformation.EmployeeId,
                ArrivalDateTime = employeeInformation.ArrivalDateTime
            };
        }
    }
}
