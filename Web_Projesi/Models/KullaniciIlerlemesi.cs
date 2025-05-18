using System.ComponentModel.DataAnnotations;

namespace Web_Projesi.Models
{
    public class KullaniciIlerlemesi
    {
        public int IlerlemeID { get; set; }
        public int KullaniciID { get; set; }
        public int KelimeID { get; set; }
        public string Durum { get; set; } = string.Empty;
        public virtual Kullanicilar? Kullanici { get; set; }
        public virtual Kelimeler? Kelime { get; set; }
    }
}