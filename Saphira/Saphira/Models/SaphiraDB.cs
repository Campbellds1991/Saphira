using System.Data.OleDb;
using System.Data.Entity;

namespace Saphira.Models
{
    public class SaphiraDB : DbContext
    {
        public SaphiraDB() : base("SaphiraDB")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().HasOptional(e => e.equipment).WithOptionalDependent().WillCascadeOnDelete(false);
            modelBuilder.Entity<Employee>().HasOptional(m => m.maintenance).WithOptionalDependent().WillCascadeOnDelete(false);
            modelBuilder.Entity<Equipment>().HasOptional(m => m.maintenance).WithOptionalDependent().WillCascadeOnDelete(true);
            modelBuilder.Entity<Person>().HasOptional(m => m.maintenance).WithOptionalDependent().WillCascadeOnDelete(false);
        }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Equipment> Equipments { get; set; }
        public virtual DbSet<Maintenance> Maintenances { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }

        public System.Data.Entity.DbSet<Saphira.Models.Person> People { get; set; }
    }
}