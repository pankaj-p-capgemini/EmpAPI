//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class employee_personal_data
    {
        public int id { get; set; }
        public string religion { get; set; }
        public string gender { get; set; }
        public System.DateTime dob { get; set; }
        public string marital_status { get; set; }
        public int emp_id { get; set; }
    
        public virtual employee employee { get; set; }
    }
}