using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security;
using System.Web;

namespace Saphira.Models
{
    [Table("UserAccounts")]
    public class Account
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Display(Name = "Created On")]
        [DataType(DataType.Date)]
        public DateTime DateCreated
        {
            get { return this.DateCreated.ToLocalTime(); }
            set { value = DateTime.UtcNow; }
        }

    }
}