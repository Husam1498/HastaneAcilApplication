using System.ComponentModel.DataAnnotations;

namespace AplicationWebUi.Models
{
    public class RegisterModel
    {
        public int UserId { get; set; }
        [Required(ErrorMessage ="İsim Soy isim Zorunludur!")]
        [StringLength(25,ErrorMessage ="En fazla 25 karakter olmalı")]
        public string Fullname { get; set; }
        [Required(ErrorMessage = "Username girmek Zorunludur!")]
        [MaxLength(10, ErrorMessage = "Kullanıcı adı en fazla 10 karakter olmalı"), MinLength(4)]
       
        public string Username { get; set; }
        [Required(ErrorMessage = "Password Zorunludur!")]
        [MinLength(4, ErrorMessage = "En az 4 karakterden oluşmalı şifreniz")]
        [DataType(DataType.Password)]
        
        public string Password { get; set; }
        [Required(ErrorMessage = "Lütfen şifrenizi Tekrar girmelisiniz!")]
        [Compare(nameof(Password),ErrorMessage ="Şifreniz eşleşmiyor!")]
        [DataType(DataType.Password)]
        public string RePasword { get; set; }
        [Required(ErrorMessage = "Email Zorunludur!")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Düzgün bir email adresi giriniz")]
        public string email { get; set; }
        [Required(ErrorMessage = "Role  Zorunludur!")]
        public string Role { get; set; }

    }
}
