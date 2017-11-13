using POP_12.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_12.Model
{
    class Projekat
    {
        public Projekat Instance { get; } = new Projekat();
        public List<TipNamestaja> TipoviNamestaja { get; set; }
        private List<Namestaj> namestaj = new List<Model.Namestaj>();

        public List<Namestaj> Namestaj
        {
            get
            {
                this.namestaj = GenericSerializer.Deserialize<Namestaj>("namestaj.xml");
                return this.namestaj;
            }
            set
            {
                this.namestaj = value;
                GenericSerializer.Serialize<Namestaj>("namestaj.xml", this.namestaj);
            }
        }
        public Projekat()
        {
            Instance = new Projekat();



        }
    }
}
}
