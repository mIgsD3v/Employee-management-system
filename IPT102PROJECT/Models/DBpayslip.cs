using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace IPT102PROJECT.Models
{
    public partial class DBpayslip : DbContext
    {
        public DBpayslip()
            : base("name=DBpayslip")
        {
        }

        public virtual DbSet<Payslip> Payslips { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payslip>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }
    }
}
