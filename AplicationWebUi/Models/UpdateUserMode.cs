using System.ComponentModel.DataAnnotations;

namespace AplicationWebUi.Models
{
    public class UpdateUserMode
    {

        public int UserId { get; set; }
       
        [StringLength(25, ErrorMessage = "En fazla 25 karakter olmalı")]
        public string Fullname { get; set; }
       
        [MaxLength(10, ErrorMessage = "Kullanıcı adı en fazla 10 karakter olmalı"), MinLength(4)]
        [Display(Name = "Username")]
        public string Username { get; set; }     
        [DataType(DataType.EmailAddress, ErrorMessage = "Düzgün bir email adresi giriniz")]
        public string email { get; set; }
        public string Role { get; set; }

    }
}
