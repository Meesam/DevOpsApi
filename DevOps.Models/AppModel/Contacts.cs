﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DevOps.Models.AppModel
{
    public class Contacts: DateTimeClass
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
        [MaxLength(255)]
        public string? Street { get; set; }

        [Required]
        [MaxLength(100)]
        public string? City { get; set; }

        [Required]
        [MaxLength(20)]
        public string? State { get; set; }

        [Required]
        [MaxLength(50)]
        public string? PostalCode { get; set; }

        public int CustomerId { get; set; }

        [JsonIgnore]
        public Customer? Customer { get; set; }
    }
}
