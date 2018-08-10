using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Cors;
using EmpAPI.ErrorHelper;
using EmpAPI.ActionFilters;
using BusinessEntities;
using BusinessServices;

namespace EmpAPI.Controllers
{
    // Enabling Cross-Origin Requests (CORS) for all controller methods
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class EmployeesController : ApiController
    {
        private readonly IEmployeeServices<EmployeeEntity> _employeeServices;

        /// <summary>  
        /// Public constructor to initialize employee service instance  
        /// </summary>  
        public EmployeesController()
        {
            _employeeServices = new EmployeeServices();
        }

        // GET: api/Employees
        [Route("api/v1/employees")]
        public HttpResponseMessage GetEmployees()
        {
            var empsData = _employeeServices.GetAll();
            if (empsData != null)
            {
                var employeeEntities = empsData as List<EmployeeEntity> ?? empsData.ToList();
                if (employeeEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, employeeEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employees not found");
        }
    }
}