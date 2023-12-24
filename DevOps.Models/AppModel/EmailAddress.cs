using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DevOps.Models.AppModel
{
    public class EmailAddress:DateTimeClass
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Phone { get; set; }

        [Required]
        [MaxLength(255)]
        public string? Email { get; set; }

        [Required]
        [MaxLength(20)]
        public string? EmailType { get; set; }

        [Required]
        public bool IsPrimary { get; set; } = false;

        public int CustomerId { get; set; }

        [JsonIgnore]
        public Customer? Customer { get; set; }
    }
}
