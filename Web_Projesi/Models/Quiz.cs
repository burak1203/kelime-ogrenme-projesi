using System.ComponentModel.DataAnnotations;

namespace Web_Projesi.Models
{
    public class Quiz
    {
        public int QuizID { get; set; }
        public int KullaniciID { get; set; }
        public int Puan { get; set; }
        public DateTime Tarih { get; set; }
        public int DogruSayisi { get; set; }
        public int ToplamSoru { get; set; }
        public virtual Kullanicilar? Kullanici { get; set; }
    }
}
