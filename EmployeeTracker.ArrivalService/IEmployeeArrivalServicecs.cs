using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTracker.ArrivalService
{
    public interface IEmployeeArrivalServicecs
    {
        Task<string> Subscribe(DateTime date, string callbackUrl);
    }
}
