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
    /// Interaction logic for EditTipa.xaml
    /// </summary>
    public partial class EditTipa : Window
    {
        private TipNamestaja tipNamestaja;
        private Operacija operacija;
        public enum Operacija
        {
            DODAVANJE,
            IZMENA,

        };
        public EditTipa(Operacija operacija, TipNamestaja tipNamestaja)
        {
            InitializeComponent();
            this.tipNamestaja = tipNamestaja;
            this.operacija = operacija;
            tbNaziv.DataContext = tipNamestaja;
        }
        private void Izlaz(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            var postojeciTNamestaj = Projekat.Instance.tipovi;

            if (tbNaziv.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Niste uneli Naziv");
                return; // return because we don't want to run normal code of buton click
            }

            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    TipNamestaja.Create(tipNamestaja);
                    break;
                case Operacija.IZMENA:
                    foreach (var n in postojeciTNamestaj)
                    {
                        if (n.Id == tipNamestaja.Id)
                        {
                            n.Naziv = tipNamestaja.Naziv;
                            TipNamestaja.Update(n);
                            break;
                        }
                    }
                    break;
            }


            this.Close();

        }

    }
}
