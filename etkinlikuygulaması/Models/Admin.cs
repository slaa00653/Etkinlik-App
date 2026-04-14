using System.ComponentModel.DataAnnotations;

namespace etkinlikuygulaması.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string TC { get; set; }

        [Required]
        public string Sifre { get; set; }
    }
}
