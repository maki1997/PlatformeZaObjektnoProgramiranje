
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF_12_GUI.Model
{
    [Serializable]
    public class Namestaj : INotifyPropertyChanged
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value;
                OnPropertyChanged("Id");
            }
        }


        private string naziv;

        public string Naziv
        {
            get { return naziv; }
            set { naziv = value;
                OnPropertyChanged("Naziv");
            }
        }
        private int cena;

        public int Cena
        {
            get { return cena; }
            set { cena = value;
                OnPropertyChanged("Cena");
            }
        }
        private int kolicina;

        public int Kolicina
        {
            get { return kolicina; }
            set { kolicina = value;
                OnPropertyChanged("Kolicina");
            }
        }
        private bool obrisan;

        public bool Obrisan
        {
            get { return obrisan; }
            set { obrisan = value;
                OnPropertyChanged("Obrisan");

            }
        }
        private int tipN;

        public int TipN
        {
            get { return tipN; }
            set { tipN = value;
                OnPropertyChanged("TipN");
            }
        }
        private TipNamestaja tipNamestaja;

        public  TipNamestaja TipNamestaja
        {
            get {
                if (tipNamestaja == null)
                {
                    tipNamestaja = TipNamestaja.GetById(TipN);
                }
                return tipNamestaja;
                  
            }
            set { tipNamestaja = value;
                TipN = tipNamestaja.Id;
                OnPropertyChanged("TipNamestaja");
            }
        }










        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            return $"Naziv: {Naziv},{Cena},{TipNamestaja.GetById(TipN).Naziv}";
        }

        public static Namestaj GetById(int id)
        {
            foreach (var Namestaja in Projekat.Instance.Namestaj)
            {
                if (Namestaja.Id == id)
                {
                    return Namestaja;
                }

            }
            return null;

        }

        protected void OnPropertyChanged (string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
