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
using static SF_12_2016.GUI.NamestajEdit;

namespace SF_12_2016.GUI
{
    /// <summary>
    /// Interaction logic for AkcijaWindow.xaml
    /// </summary>
    public partial class AkcijskiProzor : Window
    {
        Namestaj namestaj;
        Operacija operacija;
        AkcijskaProdaja akcija = new AkcijskaProdaja();
        public AkcijskiProzor(Operacija operacija, Namestaj noviNamestaj)
        {
            InitializeComponent();

            this.namestaj = noviNamestaj;
            this.operacija = operacija;

            tbPopust.DataContext = akcija;
            dpP.DataContext = akcija;
            dpK.DataContext = akcija;


        }

        private void Izlaz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            //uporedjuje datume ako je pocetni manji doda
            var akcijaa = Projekat.Instance.akcija;
            DateTime pocetni = dpP.SelectedDate.Value.Date;
            DateTime krajnji = dpK.SelectedDate.Value.Date;
            int result = DateTime.Compare(pocetni, krajnji);
            if (result < 0 || result == 0)
            {
                var Id = akcijaa.Count + 1;
                akcija.Id = Id;
                namestaj.ak = Id;

                akcijaa.Add(akcija);
            }
            else
            {
                MessageBox.Show("Akcija ne moze da istekne pre nego sto je pocela", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            GenericSerializer.Serialize("akcija.xml", akcijaa);
            this.Close();

        }

        private void Button_KeyDown(object sender,KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var akcijaa = Projekat.Instance.akcija;
                DateTime pocetni = dpP.SelectedDate.Value.Date;
                DateTime krajnji = dpK.SelectedDate.Value.Date;
                int result = DateTime.Compare(pocetni, krajnji);
                if (result < 0 || result == 0)
                {
                    var Id = akcijaa.Count + 1;
                    akcija.Id = Id;
                    namestaj.ak = Id;

                    akcijaa.Add(akcija);
                }
                else
                {
                    MessageBox.Show("Akcija ne moze da istekne pre nego sto je pocela", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                GenericSerializer.Serialize("akcija.xml", akcijaa);
                this.Close();

            }
        }



    }
}
