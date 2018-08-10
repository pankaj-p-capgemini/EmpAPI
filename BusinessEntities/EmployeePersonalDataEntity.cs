using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    class EmployeePersonalDataEntity
    {
        public int Id { get; set; }
        public string Religion { get; set; }
        public string Gender { get; set; }
        public System.DateTime Dob { get; set; }
        public string Marital_status { get; set; }
        public int Emp_id { get; set; }
    }
}
