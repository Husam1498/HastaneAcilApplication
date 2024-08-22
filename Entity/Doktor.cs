using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Doktor
    {
        public int DoktorId { get; set; }
        public string DoktorFUllname { get; set; }
        public List<Hasta> hastalars { get; set; }
        public AcilServisAlan Alan { get; set; }
        public int AlanId { get; set; }
    }
}
