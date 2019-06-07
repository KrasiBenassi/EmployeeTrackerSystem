using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTraker.DataLayer
{
    public class EmployeeArrivalRepository : IEmployeeArrivalRepository<EmployeeInformation>
    {
        public void Add(EmployeeInformation entity)
        {
            using (EmployeeTrackerEntitiesConnection context = new EmployeeTrackerEntitiesConnection())
            {
                context.EmployeeArrivalInformations.Add(entity);
                context.SaveChanges();
            }
        }

        public void AddRange(IEnumerable<EmployeeInformation> entities)
        {
            using (EmployeeTrackerEntitiesConnection context = new EmployeeTrackerEntitiesConnection())
            {
                context.EmployeeArrivalInformations.AddRange(entities.Select(e => (EmployeeArrivalInformation)e));
                context.SaveChanges();
            }
        }

        public IEnumerable<EmployeeInformation> GetAll()
        {
            using (EmployeeTrackerEntitiesConnection context = new EmployeeTrackerEntitiesConnection())
            {
                return context.EmployeeArrivalInformations.ToList().Select(e => (EmployeeInformation)e);
            }
        }

        public EmployeeInformation GetById(int id)
        {
            using (EmployeeTrackerEntitiesConnection context = new EmployeeTrackerEntitiesConnection())
            {
                return context.EmployeeArrivalInformations.Find(id);
            }
        }
    }
}
