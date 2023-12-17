using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace IPT102PROJECT.Models
{
    public partial class DBcontactlist : DbContext
    {
        public DBcontactlist()
            : base("name=DBcontactlist")
        {
        }

        public virtual DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>()
                .Property(e => e.Firstname)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Lastname)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Cellphonenumber)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Socialnetwork)
                .IsUnicode(false);
        }
    }
}
