using System.ComponentModel.DataAnnotations;

namespace Web_Projesi.Models
{
    public class KelimeYonetimViewModel
    {
        public int KelimeID { get; set; }

        [Required(ErrorMessage = "Kelime alanı zorunludur.")]
        [Display(Name = "Kelime")]
        public string KelimeAdi { get; set; } = string.Empty;

        [Required(ErrorMessage = "Tanım alanı zorunludur.")]
        [Display(Name = "Tanım")]
        public string Tanim { get; set; } = string.Empty;

        [Required(ErrorMessage = "Tür alanı zorunludur.")]
        [Display(Name = "Tür")]
        public string Tur { get; set; } = string.Empty;

        [Display(Name = "Örnek Cümle")]
        public string? OrnekCumle { get; set; }
    }
}