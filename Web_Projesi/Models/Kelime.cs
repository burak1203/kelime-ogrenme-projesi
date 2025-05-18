using System.ComponentModel.DataAnnotations;

namespace Web_Projesi.Models
{
    public class Kelime
    {
        public int KelimeID { get; set; }

        [Required]
        [StringLength(100)]
        public required string Kelime_Adi { get; set; }

        public string? Tanim { get; set; }

        [StringLength(50)]
        public string? Tur { get; set; }

        public string? OrnekCumle { get; set; }

        // Navigation properties
        public ICollection<KullaniciIlerlemesi> KullaniciIlerlemeleri { get; set; } = new List<KullaniciIlerlemesi>();
        public ICollection<KelimeKategori> KelimeKategorileri { get; set; } = new List<KelimeKategori>();
    }
}