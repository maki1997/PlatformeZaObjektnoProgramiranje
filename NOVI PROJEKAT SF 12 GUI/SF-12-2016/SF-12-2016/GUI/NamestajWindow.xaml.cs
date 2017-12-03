using SF_12_2016.Model;
using SF_12_2016.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for NamestajWindow.xaml
    /// </summary>
    public partial class NamestajWindow : Window
    {
        public enum Rad
        {
            Namestaj,
            TipNamestaja,
            Korisnik,
            ProdajaNamestaja,


        };
        private ICollectionView view;
        Rad rad;
        public SizeToContent SizeToContent { get; set; }
        public NamestajWindow(Rad rad)
        {
            InitializeComponent();
            this.SizeToContent = SizeToContent.WidthAndHeight;
            this.rad = rad;

            switch (rad)
            {
                case Rad.Namestaj:
                    view = CollectionViewSource.GetDefaultView(Projekat.Instance.namestaj);
                    view.Filter = namestajFileter;
                    dgPrikaz.ItemsSource = view;
                    dgPrikaz.IsSynchronizedWithCurrentItem = true;
                    dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    break;
                case Rad.TipNamestaja:
                    view = CollectionViewSource.GetDefaultView(Projekat.Instance.tipovi);
                    view.Filter = tipnamestajFileter;
                    dgPrikaz.ItemsSource = view;
                    dgPrikaz.IsSynchronizedWithCurrentItem = true;
                    dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    break;
                case Rad.Korisnik:
                    view = CollectionViewSource.GetDefaultView(Projekat.Instance.korisnik);
                    view.Filter = korisnikFileter;
                    dgPrikaz.ItemsSource = view;
                    dgPrikaz.IsSynchronizedWithCurrentItem = true;
                    dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
                    break;
                case Rad.ProdajaNamestaja:
                    dgPrikaz.ItemsSource = Projekat.Instance.racun;
                    dgPrikaz.IsSynchronizedWithCurrentItem = true;
                    btObrisi.Visibility = System.Windows.Visibility.Hidden;
                    break;



            }

        }

        private bool namestajFileter(object obj)
        {
            return ((Namestaj)obj).Obrisan == false;
        }
        private bool tipnamestajFileter(object obj)
        {
            return ((TipNamestaja)obj).Obrisan == false;
        }
        private bool korisnikFileter(object obj)
        {
            return ((Korisnik)obj).Obrisan == false;
        }

        private void Izlaz(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Dodaj(object sender, RoutedEventArgs e)
        {

            switch (rad)
            {
                case Rad.Namestaj:
                    DodajNamestaj();
                    break;
                case Rad.TipNamestaja:
                    DodajTipNamestaja();
                    break;
                case Rad.Korisnik:
                    DodajKorisnika();
                    break;
                case Rad.ProdajaNamestaja: break;


            }


        }
        private void Izmeni(object sender, RoutedEventArgs e)
        {
            switch (rad)
            {
                case Rad.Namestaj:
                    IzmeniNamestaj();
                    break;
                case Rad.TipNamestaja:
                    IzmeniTipNamestaja();
                    break;
                case Rad.Korisnik:
                    IzmeniKorisnik();
                    break;
                case Rad.ProdajaNamestaja: break;


            }

        }
        private void Obrisi(object sender, RoutedEventArgs e)
        {
            switch (rad)
            {
                case Rad.Namestaj:
                    ObrisiNamestaj();
                    break;
                case Rad.TipNamestaja:
                    ObrisiTipNamestaj();
                    break;
                case Rad.Korisnik:
                    ObrisiKorisnika();
                    break;



            }
        }
        private void DodajNamestaj()
        {
            var noviNamestaj = new Namestaj()
            {
                Naziv = ""
            };
            var namestajProzor = new NamestajEdit(noviNamestaj, Operacija.DODAVANJE);
            namestajProzor.ShowDialog();
        }
        private void DodajTipNamestaja()
        {
            var tn = new TipNamestaja()
            {
                Naziv = ""
            };
            var namestajProzor = new EditTipa(EditTipa.Operacija.DODAVANJE, tn);
            namestajProzor.ShowDialog();
        }
        private void DodajKorisnika()
        {
            var k = new Korisnik();
            var korisnikProzor = new EditKorisnika(EditKorisnika.Operacija.DODAVANJE, k);
            korisnikProzor.ShowDialog();
        }
        private void IzmeniNamestaj()
        {
            var selektovaniNamestaj = (Namestaj)dgPrikaz.SelectedItem;
            var namestajProzor = new NamestajEdit(selektovaniNamestaj, Operacija.IZMENA);
            namestajProzor.ShowDialog();
        }
        private void IzmeniTipNamestaja()
        {
            var selektovaniTNamestaja = (TipNamestaja)dgPrikaz.SelectedItem;
            var namestajProzor = new EditTipa(EditTipa.Operacija.IZMENA, selektovaniTNamestaja);
            namestajProzor.ShowDialog();
        }
        private void IzmeniKorisnik()
        {
            var selektovaniKorisnki = (Korisnik)dgPrikaz.SelectedItem;
            var prozor = new EditKorisnika(EditKorisnika.Operacija.IZMENA, selektovaniKorisnki);
            prozor.ShowDialog();
        }

        private void ObrisiNamestaj()
        {
            var staraListaN = Projekat.Instance.namestaj;
            var nam = (Namestaj)dgPrikaz.SelectedItem;

            if (MessageBox.Show($"Da li ste sigurni da zelite da izbrisete izabrani namestaj: {nam.Naziv}?", "Poruka o brisanju ", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                foreach (var n in staraListaN)
                {
                    if (n.Id == nam.Id)
                    {
                        n.Obrisan = true;
                        view.Refresh();
                        break;
                    }

                }
            }
            GenericSerializer.Serialize("namestaj.xml", Projekat.Instance.namestaj);
        }
        private void ObrisiTipNamestaj()
        {
            var staraListaN = Projekat.Instance.tipovi;
            var tn = (TipNamestaja)dgPrikaz.SelectedItem;

            if (MessageBox.Show($"Da li ste sigurni da zelite da izbrisete izabrani tip namestaj: {tn.Naziv}?", "Poruka o brisanju ", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                foreach (var n in staraListaN)
                {
                    if (n.Id == tn.Id)
                    {
                        n.Obrisan = true;
                        view.Refresh();
                        break;
                    }

                }
            }
            GenericSerializer.Serialize("tipnamestaja.xml", Projekat.Instance.tipovi);
        }
        private void ObrisiKorisnika()
        {
            var staraListaN = Projekat.Instance.korisnik;
            var korisnik = (Korisnik)dgPrikaz.SelectedItem;

            if (MessageBox.Show($"Da li ste sigurni da zelite da izbrisete izabranog korisnika: {korisnik.Ime} {korisnik.Prezime}?", "Poruka o brisanju ", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                foreach (var n in staraListaN)
                {
                    if (n.Id == korisnik.Id)
                    {
                        n.Obrisan = true;
                        view.Refresh();
                        break;
                    }

                }
            }
            GenericSerializer.Serialize("korisnik.xml", Projekat.Instance.korisnik);
        }


        private void dgPrikaz_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (rad)
            {
                case Rad.Namestaj:
                    if ((string)e.Column.Header == "Obrisan" || (string)e.Column.Header == "Id" || (string)e.Column.Header == "ak" || (string)e.Column.Header == "TipN")
                    {
                        e.Cancel = true;
                    }

                    break;
                case Rad.TipNamestaja:
                    if ((string)e.Column.Header == "Obrisan" || (string)e.Column.Header == "Id")
                    {
                        e.Cancel = true;
                    }
                    break;
                case Rad.Korisnik:
                    if ((string)e.Column.Header == "Obrisan" || (string)e.Column.Header == "Id")
                    {
                        e.Cancel = true;
                    }
                    break;
            }

        }
    }
}
