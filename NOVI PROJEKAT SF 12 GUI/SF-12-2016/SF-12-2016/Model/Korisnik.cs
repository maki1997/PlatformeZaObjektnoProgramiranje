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
    public enum TipKorisnika
    {
        Administrator,
        Prodavac
       
     }

    public class Korisnik : INotifyPropertyChanged
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
        private string ime;
        public string Ime
        {
            get { return ime; }
            set { ime = value; OnPropertyChanged("Ime"); }
        }
        private string prezime;
        public string Prezime
        {
            get { return prezime; }
            set { prezime = value; OnPropertyChanged("Prezime"); }
        }
        private string korisnickoIme;
        public string KorisnickoIme
        {
            get { return korisnickoIme; }
            set { korisnickoIme = value; OnPropertyChanged("KorisnickoIme"); }
        }
        private string lozinka;
        public string Lozinka
        {
            get { return lozinka; }
            set { lozinka = value; OnPropertyChanged("Lozinka"); }
        }


        private bool obrisan;
        public bool Obrisan
        {
            get { return obrisan; }
            set { obrisan = value; OnPropertyChanged("Obrisan"); }
        }
        private TipKorisnika tip;
        [XmlIgnore]
        public TipKorisnika TipKorisnika
        {
            get { return tip; }
            set { tip = value; OnPropertyChanged("TipKorisnika"); }
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
        public static ObservableCollection<Korisnik> GetAll()
        {
            var Korisnici = new ObservableCollection<Korisnik>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM Korisnik WHERE Obrisan=0";

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = cmd;
                da.Fill(ds, "Korisnik"); // Query se izvrsava
                foreach (DataRow row in ds.Tables["Korisnik"].Rows)
                {
                    var k = new Korisnik();
                    k.Id = int.Parse(row["Id"].ToString());
                    k.Ime = row["Ime"].ToString();
                    k.Prezime = row["Prezime"].ToString();
                    k.KorisnickoIme = row["KorisnickoIme"].ToString();
                    k.Lozinka = row["Lozinka"].ToString();
                    k.Obrisan = bool.Parse(row["Obrisan"].ToString());
                    // tip korisnika
                    Korisnici.Add(k);

                }
                return Korisnici;
            }
        }
        public static Korisnik Create(Korisnik k)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ToString()))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = $"INSERT INTO Korisnik (Ime,Prezime,KorisnickoIme,Lozinka,Obrisan) VALUES (@Ime,@Prezime,@KorisnickoIme,@Lozinka,@Obrisan);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";

                cmd.Parameters.AddWithValue("Ime", k.Ime);
                cmd.Parameters.AddWithValue("Prezime", k.Prezime);
                cmd.Parameters.AddWithValue("KorisnickoIme", k.KorisnickoIme);
                cmd.Parameters.AddWithValue("Lozinka", k.Lozinka);
                cmd.Parameters.AddWithValue("Obrisan", k.Obrisan);

                int newId = int.Parse(cmd.ExecuteScalar().ToString());   // izvrsava query
                k.Id = newId;
            }
            Projekat.Instance.korisnik.Add(k);
            return k;
        }
        public static void Update(Korisnik k)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ToString()))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE Korisnik SET Ime=@Ime,Prezime=@Prezime,KorisnickoIme=@KorisnickoIme,Lozinka=@Lozinka,Obrisan=@Obrisan WHERE Id=@Id";
                cmd.Parameters.AddWithValue("Ime", k.Ime);
                cmd.Parameters.AddWithValue("Prezime", k.Prezime);
                cmd.Parameters.AddWithValue("KorisnickoIme", k.KorisnickoIme);
                cmd.Parameters.AddWithValue("Lozinka", k.Lozinka);
                cmd.Parameters.AddWithValue("Obrisan", k.Obrisan);

                cmd.ExecuteNonQuery();

                foreach (var Korisnik in Projekat.Instance.korisnik)
                {
                    if (Korisnik.Id == k.Id)
                    {
                        Korisnik.Ime = k.Ime;
                        Korisnik.Prezime = k.Prezime;
                        Korisnik.KorisnickoIme = k.KorisnickoIme;
                        Korisnik.Lozinka = k.Lozinka;
                        Korisnik.Obrisan = k.Obrisan;
                        break;
                    }
                }
            }
        }
        public static void Delete(Korisnik k)
        {
            k.Obrisan = true;
            Update(k);
        }
        #endregion
    }
}
