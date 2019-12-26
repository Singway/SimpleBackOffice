using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBackOfficeAdmin.Models
{
    public class BusinessPartner
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string CompanyName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string Tel { get; set; }
        public string Fax { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
    }
}
