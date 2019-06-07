using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTraker.DataLayer
{
    public interface IEmployeeArrivalRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        T GetById(int id);

        void Add(T entity);

        void AddRange(IEnumerable<T> entities);
    }
}
