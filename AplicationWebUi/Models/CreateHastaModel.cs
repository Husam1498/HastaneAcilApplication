using System.ComponentModel.DataAnnotations;

namespace AplicationWebUi.Models
{
    public class CreateHastaModel
    {
        public int HastaId { get; set; }
        [Required(ErrorMessage ="Fullname zorunludur!!")]
        [StringLength(50, MinimumLength =5,ErrorMessage ="en az 5-50 karakter arasında olmalıdır!")]
        public string Fullname { get; set; }

        [Required(ErrorMessage = "Dogum tarihi zorunludur!!")]
        public DateTime DateofBirth { get; set; }

        [Required(ErrorMessage = "Hastalık bilgisi zorunludur!!")]
        public string HastallikBikgisi { get; set; }

        [Required(ErrorMessage = "Gideceği doktor zorunludur!!")]
        public int DoktorId { get; set; }
    }
}
