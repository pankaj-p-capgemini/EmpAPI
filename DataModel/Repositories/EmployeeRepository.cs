using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataModel;

namespace DataModel.Repositories
{
    public class EmployeeRepository : GenericRepository<EmpDBEntities, employee>, IEmployeeRepository
    {
        public employee GetSingle(int empID)
        {
            var query = Context.employees.FirstOrDefault(x => x.id == empID);
            return query;
        }
    }
}