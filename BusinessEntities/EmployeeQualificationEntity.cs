using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    class EmployeeQualificationEntity
    {
        public int Id { get; set; }
        public string Qualification { get; set; }
        public string Institution { get; set; }
        public System.DateTime Yop { get; set; }
        public decimal Percentage { get; set; }
        public int Emp_id { get; set; }
    }
}
