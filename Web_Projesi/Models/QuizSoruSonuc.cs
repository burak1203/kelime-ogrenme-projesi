namespace Web_Projesi.Models
{
    public class QuizSoruSonuc
    {
        public string KelimeAdi { get; set; } = string.Empty;
        public string DogruCevap { get; set; } = string.Empty;
        public string KullaniciCevabi { get; set; } = string.Empty;
        public bool DogruMu { get; set; }
    }
}