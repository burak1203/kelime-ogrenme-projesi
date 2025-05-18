using System.ComponentModel.DataAnnotations;

namespace Web_Projesi.Models
{
    public class Kategori
    {
        public int KategoriID { get; set; }

        [Required]
        [StringLength(100)]
        public required string KategoriAdi { get; set; }

        // Navigation property
        public ICollection<KelimeKategori> KelimeKategorileri { get; set; } = new List<KelimeKategori>();
    }
}