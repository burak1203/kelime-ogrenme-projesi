using System.ComponentModel.DataAnnotations;

namespace Web_Projesi.Models
{
    public class QuizGecmisiViewModel
    {
        public int QuizID { get; set; }

        [Display(Name = "Puan")]
        public int Puan { get; set; }

        [Display(Name = "Tarih")]
        public DateTime Tarih { get; set; }

        [Display(Name = "Doğru Sayısı")]
        public int DogruSayisi { get; set; }

        [Display(Name = "Toplam Soru")]
        public int ToplamSoru { get; set; }

        public string BasariDurumu
        {
            get
            {
                if (Puan >= 80) return "Çok İyi";
                if (Puan >= 60) return "İyi";
                return "Geliştirilebilir";
            }
        }
    }
}