namespace Web_Projesi.Models
{
    public class Kelimeler
    {
        public int KelimeID { get; set; }
        public string KelimeAdi { get; set; } = string.Empty;
        public string Tanim { get; set; } = string.Empty;
        public string Tur { get; set; } = string.Empty;
        public string OrnekCumle { get; set; } = string.Empty;
    }
}