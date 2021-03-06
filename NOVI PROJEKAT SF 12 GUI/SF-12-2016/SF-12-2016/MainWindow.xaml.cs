﻿using SF_12_2016.GUI;
using SF_12_2016.Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SF_12_2016
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Korisnik korisnik = new Korisnik();
        public MainWindow()
        {
            InitializeComponent();
            AkcijskaProdaja.AkcijeClean();

        }
        private bool Logovanje(String id, String pass)
        {

            foreach (var k in Projekat.Instance.korisnik)
            {

                if (id.Equals(k.KorisnickoIme) && pass.Equals(k.Lozinka))
                    korisnik.TipKorisnika = k.TipKorisnika;
                if (k.Obrisan == true)
                {
                    MessageBox.Show("Korisnik je izbrisan", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                return true;

            }
            return false;
        }
        private void Potvrdi(object sender, RoutedEventArgs e)
        {

            if (tbKI.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Niste uneli korisnicko ime");
                return; // return because we don't want to run normal code of buton click
            }
            if (tbPass.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Niste uneli lozinku");
                return; // return because we don't want to run normal code of buton click
            }
            if (Logovanje(tbKI.Text, tbPass.Text) == true)
            {
                var gp = new GlavniProzor(tbKI.Text, tbPass.Text);
                gp.Show();
            }

            else { MessageBox.Show("Prijava nije uspela! Pokusajte ponovo", "Pogresno logovanje", MessageBoxButton.OK, MessageBoxImage.Error); OsveziProkaz(); }

        }

        private void OsveziProkaz()
        {
            tbKI.Clear();
            tbPass.Clear();
        }


        private void Izlaz(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

}
}