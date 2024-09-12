using System.ComponentModel.DataAnnotations;

namespace AplicationWebUi.Models
{
    public class LoginModel
    {
        [Required]
        [MaxLength(10, ErrorMessage = "Kullanıcı adı en fazla 10 karakter olmalı"),MinLength(4)]
        [Display(Name = "Username",Prompt ="JohnDoe")]
        public string Username { get; set; }
        [Required]
        [MinLength(4,ErrorMessage ="En az 4 karakter olmalı şifreniz")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

    }
}
