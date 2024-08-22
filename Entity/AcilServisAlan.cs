using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class AcilServisAlan
    {
        [Key] 
        public int AlanId { get; set; }
        public string AlanName { get; set; }
    }
}
