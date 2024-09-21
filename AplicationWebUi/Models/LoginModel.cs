using System.ComponentModel.DataAnnotations;

namespace AplicationWebUi.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Kullanıcı adı girmek zorunludur!")]   
        public string Username { get; set; }
        [Required(ErrorMessage ="Password alanı girmek zorunludur!")]      
        [DataType(DataType.Password)]
        
        public string Password { get; set; }

    }
}
