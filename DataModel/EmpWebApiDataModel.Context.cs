﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EmpDBEntities : DbContext
    {
        public EmpDBEntities()
            : base("name=EmpDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<employee> employees { get; set; }
        public virtual DbSet<employee_contacts> employee_contacts { get; set; }
        public virtual DbSet<employee_personal_data> employee_personal_data { get; set; }
        public virtual DbSet<employee_qualifications> employee_qualifications { get; set; }
    }
}
