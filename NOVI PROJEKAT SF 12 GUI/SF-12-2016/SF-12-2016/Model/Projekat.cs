using SF_12_2016.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF_12_2016.Model
{
    public class Projekat
    {
        public static Projekat Instance { get; private set; } = new Projekat();
        public ObservableCollection<TipNamestaja> tipovi;
        public ObservableCollection<Namestaj> namestaj;
        public ObservableCollection<AkcijskaProdaja> akcija;
        public ObservableCollection<DodatnaUsluga> dodaci;
        public ObservableCollection<Korisnik> korisnik;
        public ObservableCollection<Racun> racun;
        private Projekat()
        {
            tipovi = TipNamestaja.GetAll();
            namestaj = Namestaj.GetAll();
            korisnik = new ObservableCollection<Korisnik>(GenericSerializer.Deserialize<Korisnik>("korisnik.xml"));
            dodaci = new ObservableCollection<DodatnaUsluga>(GenericSerializer.Deserialize<DodatnaUsluga>("dodatnausluga.xml"));
            racun = new ObservableCollection<Racun>(GenericSerializer.Deserialize<Racun>("prodajanamestaja.xml"));
            akcija = new ObservableCollection<AkcijskaProdaja>(GenericSerializer.Deserialize<AkcijskaProdaja>("akcija.xml"));
        }


    }
}
