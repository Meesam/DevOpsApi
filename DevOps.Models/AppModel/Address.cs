using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOps.Models.AppModel
{
    public class Address:DateTimeClass
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string? Street { get; set; }

        [Required]
        [MaxLength(100)]
        public string? City { get; set; }

        [Required]
        [MaxLength(20)]
        public string? State { get; set; }

        [Required]
        [MaxLength(20)]
        public string? AddressType { get; set; }

        [Required]
        public bool IsCurrentAddress { get; set; } = false;

        [Required]
        [MaxLength(50)]
        public string? PostalCode { get; set; }
    }
}
