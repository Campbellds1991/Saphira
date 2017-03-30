using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Saphira.Models
{
	public enum Cond : int
	{
		New = 0,
		Good = 1,
		Fair = 2,
		Poor = 3,
		VeryPoor = 4,
		Failed = 5
	}
	public enum Service : int
	{
		Preventitive, BreakFix, Redtag, Decommissioned, ReturnToService, Cosmetic, Other
	}
    [Table("Employees")]
	public class Employee
	{        
        [Key]
        public int ID { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public string Middle { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string PrimaryPhone { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string SecondaryPhone { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name = "Pay Rate")]
		[Required]
		[DataType(DataType.Currency)]
        public decimal PayRate { get; set; }
		public string Shift { get; set; }
		[Display(Name = "Start Date")]
		[Required]
		[DataType(DataType.Date)]
		public System.DateTime StartDate { get; set; }
		[Display(Name = "End Date")]
		[DataType(DataType.Date)]
		public Nullable<System.DateTime> EndDate { get; set; }
		public bool FullTime { get; set; }
		public bool Volunteer { get; set; }

		
		
		
	}
    [Table("Equipment")]
	public class Equipment
	{
        [Key]
		public int Id { get; set; }
		public string Type { get; set; }
		public string Make { get; set; }
		public string Model { get; set; }
		[Display(Name = "Serial Number")]
		public string SerialNum { get; set; }
		public string Vendor { get; set; }
		[Display(Name = "Invoice Number")]
		public string InvoiceNum { get; set; }
		[Display(Name = "Date Purchased")]
		[DataType(DataType.Date)]
		public Nullable<System.DateTime> PurchaseDate { get; set; }
		[Display(Name = "Date of last service")]
		[DataType(DataType.Date)]
		public System.DateTime LastServiced { get; set; }
		public Nullable<Cond> Condition { get; set; }
		public string Description { get; set; }
		[Display(Name = "Service Requested?")]
		public Nullable<bool> ServiceRequested { get; set; }
		[Display(Name = "Where is it?")]
		public string Location { get; set; }
		[Display(Name = "Designated User")]
		public Nullable<int> AssignedTo { get; set; }
	}
    [Table("Maintenance")]
	public class Maintenance
	{
        [Key]
		public int Id { get; set; }
		[Display(Name = "Logged By")]
		public Person Perso_LoggedBy { get; set; }
		public Equipment Equip_Serviced { get; set; }
		public Service ServiceCode { get; set; }
		public Cond PreServCond { get; set; }
		public Cond PostServCond { get; set; }
		public string DescOfService { get; set; }
		[DataType(DataType.Date)]
		public DateTime ServDateIn { get; set; }
		[DataType(DataType.Date)]
		public DateTime ServDateOut { get; set; }
		[DataType(DataType.Currency)]
		public decimal Cost { get; set; }
		public Person ServicedBy { get; set; }
	}
    [Table("Persons")]
	public class Person
	{
        [Key]
        public int ID { get; set; }
        public string Affiliation { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public string Middle { get; set; }        
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string PrimaryPhone { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string SecondaryPhone { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
    }
}