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

            if (tbIme.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Niste uneli ime");
                return; // return because we don't want to run normal code of buton click
            }

            if (tbKI.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Niste uneli korisnicko ime");
                return; // return because we don't want to run normal code of buton click
            }



            if (tbLozinka.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Niste uneli lozinku");
                return; // return because we don't want to run normal code of buton click
            }

            if (tbPrezime.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Niste uneli prezime");
                return; // return because we don't want to run normal code of buton click
            }
            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    if (Korisnik.KorisnikPostoji(korisnik.KorisnickoIme) == false)
                    {
                        Korisnik.Create(korisnik);
                    }
                    else
                    {
                        MessageBox.Show("Postoji korisnik sa tim korisnickim imenom izaberite drugo", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    break;
                case Operacija.IZMENA:
                    foreach (var k in korisnici)
                    {
                        if (k.Id == korisnik.Id)
                        {
                            if (Korisnik.KorisnikPostoji(korisnik.KorisnickoIme) == false)
                            {
                                k.Ime = korisnik.Ime;
                                k.Prezime = korisnik.Prezime;
                                k.KorisnickoIme = korisnik.KorisnickoIme;
                                k.Lozinka = korisnik.Lozinka;
                                k.TipKorisnika = korisnik.TipKorisnika;
                                Korisnik.Update(k);
                            }
                            else
                            {
                                MessageBox.Show("Postoji korisnik sa tim korisnickim imenom izaberite drugo", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                            break;
                        }
                    }
                    break;
            }

            this.Close();
        }
    }
}

