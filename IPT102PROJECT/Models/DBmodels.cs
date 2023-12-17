using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace IPT102PROJECT.Models
{
    public partial class DBmodels : DbContext
    {
        public DBmodels()
            : base("name=DBmodels")
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Position)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Cityaddress)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Department)
                .IsUnicode(false);
        }
    }
}
