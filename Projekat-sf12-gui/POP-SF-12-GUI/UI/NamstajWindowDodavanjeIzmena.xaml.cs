using POP_SF_12_GUI.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace POP_SF_12_GUI.UI
{
    /// <summary>
    /// Interaction logic for NamstajWindowDodavanjeIzmena.xaml
    /// </summary>

    public partial class NamstajWindowDodavanjeIzmena : Window
    {
        private Namestaj namestaj;
        private Operacija operacija;
        public enum Operacija
        {
            DODAVANJE,
            IZMENA,

        };
        public NamstajWindowDodavanjeIzmena(Namestaj noviNamestaj, Operacija operacija)
        {
            InitializeComponent();

            this.namestaj = namestaj;
            this.operacija = operacija;

            cbTipNamestaja.ItemsSource = Projekat.Instance.TipoviNamestaja;


            tbNaziv.DataContext = namestaj;
            cbTipNamestaja.DataContext = namestaj;
        }

        private void Izlaz(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void SacuvajNamestaj(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Namestaj> postojeciNamestaj = Projekat.Instance.Namestaj;
            var tn = (TipNamestaja)cbTipNamestaja.SelectedItem;
            switch (operacija)
            {

                case Operacija.DODAVANJE:

                    namestaj.Id = Projekat.Instance.Namestaj.Count + 1;
                    Projekat.Instance.Namestaj.Add(namestaj);
                    break;
                case Operacija.IZMENA:
                    foreach (var n in postojeciNamestaj)
                    {
                        if (n.Id == namestaj.Id)
                        {
                            n.TipN = namestaj.TipN;
                            n.Naziv = namestaj.Naziv;
                            break;
                        }
                    }
                    break;



            }
            GenericSerializer.Serialize("namestaj.xml", Projekat.Instance.Namestaj);

            Projekat.Instance.Namestaj = postojeciNamestaj;
            this.Close();
        }
        private static int NoviIDzaNamestaj()
        {
            int j = 0;
            foreach (var namestaj in Projekat.Instance.Namestaj)
            {
                if (j <= namestaj.Id)
                    j = namestaj.Id;

            }
            return j + 1;
        }

  /*      private void DodajAkciju(object sender, RoutedEventArgs e)
        {
            var akcija = new AkcijaWindow(Operacija.DODAVANJE, namestaj);
            akcija.ShowDialog();
        } */

    }
}

