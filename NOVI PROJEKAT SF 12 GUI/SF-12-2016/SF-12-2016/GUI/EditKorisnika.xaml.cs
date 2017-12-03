﻿using SF_12_2016.Model;
using SF_12_2016.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SF_12_2016.GUI
{
    /// <summary>
    /// Interaction logic for EditKorisnika.xaml
    /// </summary>
    public partial class EditKorisnika : Window
    {
        private Korisnik korisnik;
        private Operacija operacija;
        public enum Operacija
        {
            DODAVANJE,
            IZMENA,

        };
        public EditKorisnika(Operacija operacija, Korisnik korisnik)
        {
            InitializeComponent();
            this.operacija = operacija;
            this.korisnik = korisnik;
            tbIme.DataContext = korisnik;
            tbKI.DataContext = korisnik;
            tbLozinka.DataContext = korisnik;
            tbPrezime.DataContext = korisnik;
            cbTipNamestaja.ItemsSource = Enum.GetValues(typeof(TipKorisnika)).Cast<TipKorisnika>();
            //treba da se doda u cb
            cbTipNamestaja.DataContext = korisnik;
            cbTipNamestaja.SelectedIndex = 0;
        }
        private void Izlaz(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Sacuvaj_Korisnik(object sender, RoutedEventArgs e)
        {
            var korisnici = Projekat.Instance.korisnik;
            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    var id = korisnici.Count + 1;
                    korisnik.Id = id;
                    korisnici.Add(korisnik);
                    break;
                case Operacija.IZMENA:
                    foreach (var k in korisnici)
                    {
                        if (k.Id == korisnik.Id)
                        {
                            k.Ime = korisnik.Ime;
                            k.Prezime = korisnik.Prezime;
                            k.KorisnickoIme = korisnik.KorisnickoIme;
                            k.Lozinka = korisnik.Lozinka;
                            k.TipKorisnika = korisnik.TipKorisnika;
                            break;
                        }
                    }
                    break;
            }
            GenericSerializer.Serialize("korisnik.xml", korisnici);
            this.Close();
        }
    }
}