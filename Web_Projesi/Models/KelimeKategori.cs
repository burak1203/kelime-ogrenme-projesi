namespace Web_Projesi.Models
{
    public class KelimeKategori
    {
        public int KelimeID { get; set; }
        public Kelime? Kelime { get; set; }

        public int KategoriID { get; set; }
        public Kategori? Kategori { get; set; }
    }
}