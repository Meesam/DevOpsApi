using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOps.Models.AppModel
{
    public class Customer : DateTimeClass
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string? Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string? Website { get; set; }

        [Required]
        [MaxLength(255)]
        public string? LogoUrl { get; set; }

        public List<Address> AddressList { get; set; } = new List<Address>();

        public List<EmailAddress> EmailAddresses { get; set; } = new List<EmailAddress>();

        public List<Project> Projects { get; set; } = new List<Project>();
    }
}
