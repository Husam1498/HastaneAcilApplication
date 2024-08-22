using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Hasta
    {
        public int HastaId { get; set; }
        public string HastaFullname { get; set; }
        public string DateBirth { get; set; }
        public string HastlıkBilgisi { get; set; }

        public Doktor doktor { get; set; }
        public int DoktorId { get; set; }
    }
}
