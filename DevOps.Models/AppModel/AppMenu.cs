using System.ComponentModel.DataAnnotations;


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
      
    }
}
