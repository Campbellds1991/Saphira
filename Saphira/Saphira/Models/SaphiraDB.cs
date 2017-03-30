using System.Data.OleDb;
using System.Data.Entity;

namespace Saphira.Models
{
	public class SaphiraDB : DbContext
	{
		public SaphiraDB():base("SaphiraDB")
        {
            
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Equipment> Equipments { get; set; }
        public virtual DbSet<Maintenance> Maintenances { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }

    }
}