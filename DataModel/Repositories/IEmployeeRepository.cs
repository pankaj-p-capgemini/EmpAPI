using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace DataModel.Repositories
{
    interface IEmployeeRepository : IMainRepository<employee>
    {
        employee GetSingle(int empId);
    }
}