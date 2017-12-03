﻿using SF_12_2016.Model;
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
    /// Interaction logic for GlavniProzor.xaml
    /// </summary>
    public partial class GlavniProzor : Window
    {
        public GlavniProzor(TipKorisnika tp)
        {
            InitializeComponent();
            OsveziPrikaz(tp);
            listBox.SelectedIndex = 0;
        }
        private void OsveziPrikaz(TipKorisnika tp)
        {
            if (tp == TipKorisnika.Administrator)
            {
                listBox.Items.Clear();
                listBox.Items.Add("Rad sa namestajem");
                listBox.Items.Add("Rad sa tipom namestaja");
                listBox.Items.Add("Rad sa korisnicima");
                listBox.Items.Add("Rad sa prodajom namestaja");
            }
            else
            {
                listBox.Items.Clear();
                listBox.Items.Add("Rad sa prodajom namestaja");
            }
        }
        private void Potvrdi(object sender, RoutedEventArgs e)
        {
            var selektovanaOperacija = (String)listBox.SelectedItem;
            switch (selektovanaOperacija)
            {
                case "Rad sa namestajem":
                    var NProzor = new NamestajWindow(NamestajWindow.Prikaz.Namestaj);
                    NProzor.ShowDialog();
                    break;
                case "Rad sa tipom namestaja":
                    var TNProzor = new NamestajWindow(NamestajWindow.Prikaz.TipNamestaja);
                    TNProzor.ShowDialog();
                    break;
                case "Rad sa korisnicima":
                    var KProzor = new NamestajWindow(NamestajWindow.Prikaz.Korisnik);
                    KProzor.ShowDialog();
                    break;

                case "Rad sa prodajom namestaja":
                    var PNProzor = new NamestajWindow(NamestajWindow.Prikaz.ProdajaNamestaja);
                    PNProzor.ShowDialog();
                    break;
            }
        }
        private void Izlaz(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
