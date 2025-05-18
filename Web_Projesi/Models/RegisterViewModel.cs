using System.ComponentModel.DataAnnotations;

namespace Web_Projesi.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Kullanıcı adı gereklidir")]
        [Display(Name = "Kullanıcı Adı")]
        public required string KullaniciAdi { get; set; }

        [Required(ErrorMessage = "E-posta adresi gereklidir")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz")]
        [Display(Name = "E-posta")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Şifre gereklidir")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Şifre en az 6 karakter olmalıdır")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public required string Password { get; set; }

        [Required(ErrorMessage = "TC Kimlik numarası gereklidir")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "TC Kimlik numarası 11 haneli olmalıdır")]
        [Display(Name = "TC Kimlik No")]
        public required string TCKimlik { get; set; }

        [Required(ErrorMessage = "Ad gereklidir")]
        public required string Ad { get; set; }

        [Required(ErrorMessage = "Soyad gereklidir")]
        public required string Soyad { get; set; }

        [Required(ErrorMessage = "Doğum tarihi gereklidir")]
        [DataType(DataType.Date)]
        [Display(Name = "Doğum Tarihi")]
        public DateTime DogumTarihi { get; set; }
    }
}