using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using System.Transactions;
using BusinessEntities;
using DataModel;
using DataModel.UnitOfWork;
using DataModel.Repositories;

namespace BusinessServices
{
    public class EmployeeServices : IEmployeeServices<EmployeeEntity>
    {
        private readonly EmployeeUOW _unitOfWork;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public EmployeeServices()
        {
            _unitOfWork = new EmployeeUOW();
        }

        /// <summary>
        /// Fetches employee details by id
        /// </summary>
        /// <param name="empId"></param>
        /// <returns></returns>
        public EmployeeEntity FindByID(int empId)
        {
            var empData = _unitOfWork.EmployeeRepository.GetByID(empId);
            if (empData != null)
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<employee, EmployeeEntity>();
                });
                IMapper Mapper = config.CreateMapper();
                var employeeModel = Mapper.Map<employee, EmployeeEntity>(empData);
                return employeeModel;
            }
            return null;
        }

        /// <summary>
        /// Fetches all the employees.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EmployeeEntity> GetAll()
        {
            var empsData = _unitOfWork.EmployeeRepository.GetAll().ToList();
            if (empsData.Any())
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<employee, EmployeeEntity>();
                });
                IMapper Mapper = config.CreateMapper();
                var employeeModel = Mapper.Map<List<employee>, List<EmployeeEntity>>(empsData);
                return employeeModel;
            }
            return null;
        }

        /// <summary>
        /// Creates a employee
        /// </summary>
        /// <param name="employeeEntity"></param>
        /// <returns></returns>
        public EmployeeEntity Create(EmployeeEntity employeeEntity)
        {
            using (var scope = new TransactionScope())
            {
                var empData = new employee();
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<employee, EmployeeEntity>();
                });
                IMapper Mapper = config.CreateMapper();
                var employeeModel = Mapper.Map<employee, EmployeeEntity>(empData);

                _unitOfWork.EmployeeRepository.Insert(empData);
                _unitOfWork.SaveChanges();
                scope.Complete();
                return employeeModel;
            }
        }

        /// <summary>
        /// Updates a employee
        /// </summary>
        /// <param name="empId"></param>
        /// <param name="employeeEntity"></param>
        /// <returns></returns>
        public bool Update(int empId, EmployeeEntity employeeEntity)
        {
            var success = false;
            if (employeeEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var empData = _unitOfWork.EmployeeRepository.GetByID(empId);
                    if (empData != null)
                    {
                        var config = new MapperConfiguration(cfg => {
                            cfg.CreateMap<employee, EmployeeEntity>();
                        });
                        IMapper Mapper = config.CreateMapper();
                        var employeeModel = Mapper.Map<employee, EmployeeEntity>(empData);

                        _unitOfWork.EmployeeRepository.Update(empData);
                        _unitOfWork.SaveChanges();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        /// <summary>
        /// Deletes a particular employee
        /// </summary>
        /// <param name="empId"></param>
        /// <returns></returns>
        public bool Delete(int empId)
        {
            var success = false;
            if (empId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var empData = _unitOfWork.EmployeeRepository.GetByID(empId);
                    if (empData != null)
                    {
                        _unitOfWork.EmployeeRepository.Delete(empData);
                        _unitOfWork.SaveChanges();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }
    }
}
