using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF_12_GUI.Model
{
    public class Projekat
    {
        public static Projekat Instance { get; private set; } = new Projekat();

        public ObservableCollection<TipNamestaja> TipoviNamestaja;
        public ObservableCollection<Namestaj> Namestaj;

        private Projekat()
        {
            TipoviNamestaja = new ObservableCollection<TipNamestaja>(GenericSerializer.Deserialize<TipNamestaja>("tipnamestaja.xml"));
            Namestaj = new ObservableCollection<Namestaj>(GenericSerializer.Deserialize<Namestaj>("namestaj.xml"));
        }
    }
}
