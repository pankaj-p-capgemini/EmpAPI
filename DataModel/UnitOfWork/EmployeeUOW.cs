using System;
using System.Collections.Generic;
using System.Linq;
using DataModel;
using DataModel.UnitOfWork;

namespace DataModel.Repositories
{
    public class EmployeeUOW : IUnitOfWork
    {
        public EmployeeRepository EmployeeRepository = new EmployeeRepository();
        public EmployeeRepository _empPerObj = new EmployeeRepository();
        public EmployeeRepository _empConObj = new EmployeeRepository();
        public EmployeeRepository _empQuaObj = new EmployeeRepository();

        public EmployeeUOW()
        {

        }

        public void SaveChanges()
        {
            EmployeeRepository.Save();
        }
    }
}