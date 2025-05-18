namespace Web_Projesi.Models
{
    public class QuizViewModel
    {
        public int KelimeID { get; set; }
        public string KelimeAdi { get; set; } = string.Empty;
        public string Tanim { get; set; } = string.Empty;
        public string OrnekCumle { get; set; } = string.Empty;
        public string KullaniciCevabi { get; set; } = string.Empty;
    }
}