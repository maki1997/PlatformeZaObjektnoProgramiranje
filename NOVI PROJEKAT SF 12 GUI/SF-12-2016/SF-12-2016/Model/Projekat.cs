﻿using SF_12_2016.Utils;
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
        public ObservableCollection<Salon> saloni;
        public ObservableCollection<StavkaProdajeNamestaj> spn;
        public ObservableCollection<StavkaProdajeDU> spdu;
        private Projekat()
        {
            tipovi = TipNamestaja.GetAll();
            namestaj = Namestaj.GetAll();
            korisnik = Korisnik.GetAll();
            dodaci = DodatnaUsluga.GetAll();
            racun = Racun.GetAll();
            akcija = AkcijskaProdaja.GetAll();
            spn = StavkaProdajeNamestaj.GetAll();
            spdu = StavkaProdajeDU.GetAll();

        }


    }
}
