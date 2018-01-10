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
    /// Interaction logic for DodatnaUslugaWindow.xaml
    /// </summary>
    public partial class DodatnaUslugaWindow : Window
    {
        private DodatnaUsluga dodatnaUsluga;
        private Operacija operacija;
        public enum Operacija
        {
            DODAVANJE,
            IZMENA,

        };
        public DodatnaUslugaWindow(Operacija operacija, DodatnaUsluga dodatnaUsluga)
        {
            InitializeComponent();
            this.operacija = operacija;
            this.dodatnaUsluga = dodatnaUsluga;

            tbCena.DataContext = dodatnaUsluga;
            tbNaziv.DataContext = dodatnaUsluga;
        }
        private void Izlaz(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            var postojeciDU = Projekat.Instance.dodaci;

            if (tbNaziv.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Niste uneli Naziv");
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
                    DodatnaUsluga.Create(dodatnaUsluga);
                    break;
                case Operacija.IZMENA:
                    foreach (var n in postojeciDU)
                    {
                        if (n.Id == dodatnaUsluga.Id)
                        {
                            n.Naziv = dodatnaUsluga.Naziv;
                            n.Cena = dodatnaUsluga.Cena;
                            DodatnaUsluga.Update(n);
                            break;
                        }
                    }
                    break;
            }


            this.Close();

        }
    }
}