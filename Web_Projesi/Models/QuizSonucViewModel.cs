using System.Collections.Generic;

namespace Web_Projesi.Models
{
    public class QuizSonucViewModel
    {
        public int ToplamPuan { get; set; }
        public List<QuizSoruSonuc> Sonuclar { get; set; } = new List<QuizSoruSonuc>();
    }
}