using System.ComponentModel.DataAnnotations;

namespace EtkinlikUygulamasi.Models
{
    public class Basvuru
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Ad")]
        public string Ad { get; set; }

        [Required]
        [Display(Name = "Soyad")]
        public string Soyad { get; set; }

        [Required]
        [EmailAddress]
        public string Eposta { get; set; }

        [Required]
        [Display(Name = "TC Kimlik No")]
        public string TC { get; set; }
    }
}