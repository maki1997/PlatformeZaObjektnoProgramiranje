using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_12.Model
{
    [Serializable]

    public class DodatnaUsluga
    {
        public int id { get; set; }
        public string Naziv { get; set; }
        public double CenaUsluge { get; set; }
        public bool Obrisan { get; set; }

    }
}
