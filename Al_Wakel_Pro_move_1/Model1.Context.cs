﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Al_Wakel_Pro_move_1
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AlwakelEntities : DbContext
    {
        public AlwakelEntities()
            : base("name=AlwakelEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Center> Center { get; set; }
        public DbSet<Currency> Currency { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Operation> Operation { get; set; }
        public DbSet<sysdiagrams> sysdiagrams { get; set; }
        public DbSet<User> User { get; set; }
    }
}
