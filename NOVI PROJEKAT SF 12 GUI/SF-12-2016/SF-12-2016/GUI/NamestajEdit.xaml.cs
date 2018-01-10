using SF_12_2016.Model;
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
    /// Interaction logic for NamestajEdit.xaml
    /// </summary>

    public partial class NamestajEdit : Window
    {
        private Namestaj namestaj;
        private Operacija operacija;
        public enum Operacija
        {
            DODAVANJE,
            IZMENA,

        };
        public NamestajEdit(Namestaj noviNamestaj, Operacija operacija)
        {
            InitializeComponent();
            this.namestaj = noviNamestaj;
            this.operacija = operacija;
            cbTipNamestaja.ItemsSource = Projekat.Instance.tipovi;

            tbNaziv.DataContext = namestaj;
            tbCena.DataContext = namestaj;
            tbKuM.DataContext = namestaj;

            cbTipNamestaja.DataContext = namestaj;
            cbTipNamestaja.SelectedIndex = 0;
            if (namestaj.Akcija != null)
            {
                lbAkcija.Content = namestaj.Akcija.ToString();
            }

        }

        private void Izlaz(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void SacuvajNamestaj(object sender, RoutedEventArgs e)
        {
            var postojeciNamestaj = Projekat.Instance.namestaj;

            if (tbNaziv.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Niste uneli naziv");
                return; // return because we don't want to run normal code of buton click
            }
            if (tbKuM.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Niste uneli kolicinu");
                return; // return because we don't want to run normal code of buton click
            }
            if (tbCena.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Niste uneli cenu");
                return; // return because we don't want to run normal code of buton click
            }

            switch (operacija)
            {

                case Operacija.DODAVANJE:
                    Namestaj.Create(namestaj);


                    break;
                case Operacija.IZMENA:
                    foreach (var n in postojeciNamestaj)
                    {
                        if (n.Id == namestaj.Id)
                        {
                            n.Naziv = namestaj.Naziv;
                            n.Kolicina = namestaj.Kolicina;
                            n.Cena = namestaj.Cena;
                            n.TipN = namestaj.TipN;
                            Namestaj.Update(namestaj);
                            break;
                        }
                    }
                    break;



            }


            this.Close();
        }

        private void DodajAkciju(object sender, RoutedEventArgs e)
        {
            var akcijaa = new AkcijskaProdaja()
            {
                Obrisan = false,
            };
            var akcija = new AkcijskiProzor(operacija, namestaj, akcijaa);
            akcija.ShowDialog();
        }
    }
}