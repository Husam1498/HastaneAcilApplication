using System.ComponentModel.DataAnnotations;

namespace AplicationWebUi.Models
{
    public class RegisterModel
    {
        public int UserId { get; set; }
        [Required]
        [StringLength(25,ErrorMessage ="En fazla 25 karakter olmalı")]
        public string Fullname { get; set; }
        [Required]
        [MaxLength(10, ErrorMessage = "Kullanıcı adı en fazla 10 karakter olmalı"), MinLength(4)]
        [Display(Name = "Username", Prompt = "JohnDoe")]
        public string Username { get; set; }
        [Required]
        [MinLength(4, ErrorMessage = "En az 4 karakterden oluşmalı şifreniz")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required]
        [Compare(nameof(Password),ErrorMessage ="Şifreniz eşleşmiyor")]
        [DataType(DataType.Password)]
        public string RePasword { get; set; }
        [Required]
        [DataType(DataType.EmailAddress,ErrorMessage ="Düzgün bir email adresi giriniz")]
        public string email { get; set; }
        public string Role { get; set; }

    }
}
