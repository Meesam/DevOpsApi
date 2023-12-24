using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace DevOps.Models.AppModel
{
    public class AppMenu:DateTimeClass
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        [MaxLength(200)]
        public string Url { get; set; }

        public int CustomerId { get; set; }

        [JsonIgnore]
        public Customer? Customer { get; set; }
      
    }
}
