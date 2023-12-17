using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace IPT102PROJECT.Models
{
    public partial class DBsalary : DbContext
    {
        public DBsalary()
            : base("name=DBsalary")
        {
        }

        public virtual DbSet<Salary> Salaries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Salary>()
                .Property(e => e.Name)
                .IsUnicode(false);



        }
    }
}
