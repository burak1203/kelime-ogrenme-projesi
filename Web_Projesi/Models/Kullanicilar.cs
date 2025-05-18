namespace Web_Projesi.Models
{
    public class Kullanicilar
    {
        public int KullaniciID { get; set; }
        public string KullaniciAdi { get; set; } = string.Empty;
        public string Sifre { get; set; } = string.Empty;
        public string Eposta { get; set; } = string.Empty;
        public string TCKimlik { get; set; } = string.Empty;
        public string Ad { get; set; } = string.Empty;
        public string Soyad { get; set; } = string.Empty;
        public DateTime DogumTarihi { get; set; }
        public string Rol { get; set; } = "Kullanici";
        public string Durum { get; set; } = "Aktif";
    }
}