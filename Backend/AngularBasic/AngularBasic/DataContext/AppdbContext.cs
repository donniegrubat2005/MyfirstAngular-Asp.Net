using AngularBasic.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AngularBasic.DataContext
{
    public class AppdbContext: DbContext
    { 
    public AppdbContext(): base("name=AppdbContext") { }
    
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

    
}