using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class EmployeeEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> Salary { get; set; }
        public string Department { get; set; }
        public string Is_deleted { get; set; }
    }
}
