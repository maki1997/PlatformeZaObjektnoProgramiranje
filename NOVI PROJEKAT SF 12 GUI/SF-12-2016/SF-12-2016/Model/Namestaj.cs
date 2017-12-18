
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SF_12_2016.Model
{
    [Serializable]

        public class Namestaj : INotifyPropertyChanged

        {
            private int id;
            public int Id
            {
                get { return id; }
                set
                {
                    id = value;
                    OnPropertyChanged("Id");
                }

            }
            private string naziv;
            public string Naziv
            {
                get { return naziv; }
                set { naziv = value; OnPropertyChanged("Naziv"); }
            }
            private int cena;
            public int Cena
            {
                get { return cena; }
                set { cena = value; OnPropertyChanged("Cena"); }
            }
            private int kolicina;
            public int Kolicina
            {
                get { return kolicina; }
                set { kolicina = value; OnPropertyChanged("Kolicina"); }
            }
            private bool obrisan;
            public bool Obrisan
            {
                get { return obrisan; }
                set { obrisan = value; OnPropertyChanged("Obrisan"); }
            }
            private TipNamestaja tipNamestaja;
            [XmlIgnore]
            public TipNamestaja TipNamestaja
            {
                get
                {
                    if (tipNamestaja == null)
                    {
                        tipNamestaja = TipNamestaja.GetById(tipN);

                    }
                    return tipNamestaja;
                }
                set
                {
                    tipNamestaja = value;
                    tipN = tipNamestaja.Id;
                    OnPropertyChanged("TipNamestaja");
                }
            }
            private int tipN;
            public int TipN
            {
                get { return tipN; }
                set { tipN = value; OnPropertyChanged("TipN"); }
            }

            private int a;
            public int ak
            {
                get { return a; }
                set { a = value; OnPropertyChanged("ak"); }
            }
            private AkcijskaProdaja akcija;
            [XmlIgnore]
            public AkcijskaProdaja Akcija
            {
                get
                {
                    if (akcija == null)
                    {
                        akcija = AkcijskaProdaja.GetById(ak);

                    }
                    return akcija;
                }
                set
                {
                    akcija = value;
                    a = akcija.Id;
                    OnPropertyChanged("Akcija");
                }
            }

            public override string ToString()
            {
                return $"Naziv: {Naziv},{Cena},{TipNamestaja.GetById(TipN).Naziv}";
            }
        public static Namestaj GetById(int id)
        {
            foreach (var Namestaja in Projekat.Instance.namestaj)
            {
                if (Namestaja.Id == id)
                {
                    return Namestaja;
                }

            }
                return null;

            }
            public event PropertyChangedEventHandler PropertyChanged;


            protected void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

                }
            }
        #region Database
        public static ObservableCollection<Namestaj> GetAll()
        {
            var Namestaj = new ObservableCollection<Namestaj>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM Namestaj WHERE Obrisan=0";

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = cmd;
                da.Fill(ds, "Namestaj"); // Query se izvrsava
                foreach (DataRow row in ds.Tables["Namestaj"].Rows)
                {
                    var n = new Namestaj();
                    n.Id = int.Parse(row["Id"].ToString());
                    n.TipN = int.Parse(row["TipNamestajaId"].ToString());
                    n.Naziv = row["Naziv"].ToString();
                    n.Obrisan = bool.Parse(row["Obrisan"].ToString());
                    n.Cena = int.Parse(row["Cena"].ToString());
                    n.Kolicina = int.Parse(row["Kolicina"].ToString());
                    Namestaj.Add(n);

                }
                return Namestaj;
            }
        }
        public static Namestaj Create(Namestaj n)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ToString()))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = $"INSERT INTO TipNamestaja (TipNamestajaId,Naziv,Obrisan,Cena,Kolicina) VALUES (@TipN,@Naziv,@Obrisan,@Cena,@Kolicina);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";

                cmd.Parameters.AddWithValue("TipNamestajaId", n.TipN);
                cmd.Parameters.AddWithValue("Naziv", n.Naziv);
                cmd.Parameters.AddWithValue("Obrisan", n.Obrisan);
                cmd.Parameters.AddWithValue("Cena", n.Cena);
                cmd.Parameters.AddWithValue("Kolicina", n.Kolicina);

                int newId = int.Parse(cmd.ExecuteScalar().ToString());   // izvrsava query
                n.Id = newId;
            }
            Projekat.Instance.namestaj.Add(n);
            return n;
        }
        public static void Update(Namestaj n)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ToString()))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE Namestaj SET TipNamestajaId=@TipN,Naziv=@Naziv,Obrisan=@Obrisan,Cena=@Cena,Kolicina=@Kolicina WHERE Id=@Id";
                cmd.Parameters.AddWithValue("TipNamestajaId", n.TipN);
                cmd.Parameters.AddWithValue("Naziv", n.Naziv);
                cmd.Parameters.AddWithValue("Obrisan", n.Obrisan);
                cmd.Parameters.AddWithValue("Cena", n.Cena);
                cmd.Parameters.AddWithValue("Kolicina", n.Kolicina);

                cmd.ExecuteNonQuery();

                foreach (var Namestaj in Projekat.Instance.namestaj)
                {
                    if (Namestaj.Id == n.Id)
                    {
                        Namestaj.TipN = n.TipN;
                        Namestaj.Naziv = n.Naziv;
                        Namestaj.Obrisan = n.Obrisan;
                        Namestaj.Cena = n.Cena;
                        Namestaj.Kolicina = n.Kolicina;
                        break;
                    }
                }
            }
        }
        public static void Delete(Namestaj n)
        {
            n.Obrisan = true;
            Update(n);
        }
        #endregion
    }
}