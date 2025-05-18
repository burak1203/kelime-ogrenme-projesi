using System.ComponentModel.DataAnnotations;

namespace Web_Projesi.Models
{
    public class KullaniciYonetimViewModel
    {
        public int KullaniciID { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        public string KullaniciAdi { get; set; } = string.Empty;

        [Display(Name = "E-posta")]
        public string Eposta { get; set; } = string.Empty;

        [Display(Name = "Ad")]
        public string Ad { get; set; } = string.Empty;

        [Display(Name = "Soyad")]
        public string Soyad { get; set; } = string.Empty;

        [Display(Name = "Durum")]
        public string Durum { get; set; } = string.Empty;

        [Display(Name = "Kayıt Tarihi")]
        public DateTime KayitTarihi { get; set; }

        [Display(Name = "Son Giriş")]
        public DateTime? SonGiris { get; set; }
    }
}