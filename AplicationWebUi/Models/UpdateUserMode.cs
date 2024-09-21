using System.ComponentModel.DataAnnotations;

namespace AplicationWebUi.Models
{
    public class UpdateUserMode
    {

        public int UserId { get; set; }
       
        [StringLength(25, ErrorMessage = "En fazla 25 karakter olmalı")]
        [Required(ErrorMessage ="FUllname Zorunludur?")]
        public string Fullname { get; set; }
       
        [MaxLength(10, ErrorMessage = "Kullanıcı adı en fazla 10 karakter olmalı"), MinLength(4)]
        [Required(ErrorMessage = "Username Zorunludur?")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Email Zorunludur?")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Düzgün bir email adresi giriniz")]
        public string email { get; set; }
        public string Role { get; set; }

    }
}
