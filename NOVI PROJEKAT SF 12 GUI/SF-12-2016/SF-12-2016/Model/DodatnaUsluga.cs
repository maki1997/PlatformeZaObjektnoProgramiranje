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

namespace SF_12_2016.Model
{
    [Serializable]
    public class DodatnaUsluga : INotifyPropertyChanged
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

        public event PropertyChangedEventHandler PropertyChanged;

        public int Cena
        {
            get { return cena; }
            set { cena = value; OnPropertyChanged("Cena"); }
        }

        private bool obrisan;
        public bool Obrisan
        {
            get { return obrisan; }
            set { obrisan = value; OnPropertyChanged("Obrisan"); }
        }
        public static DodatnaUsluga GetById(int id)
        {
            foreach (var du in Projekat.Instance.dodaci)
            {
                if (du.Id == id)
                {
                    return du;
                }

            }
            return null;

        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

            }
        }
        #region Database
        public static ObservableCollection<DodatnaUsluga> GetAll()
        {
            var DodatneUsluge = new ObservableCollection<DodatnaUsluga>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM DodatnaUsluga WHERE Obrisan=0";

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = cmd;
                da.Fill(ds, "DodatnaUsluga"); // Query se izvrsava
                foreach (DataRow row in ds.Tables["DodatnaUsluga"].Rows)
                {
                    var du = new DodatnaUsluga();
                    du.Id = int.Parse(row["Id"].ToString());
                    du.Naziv = row["Naziv"].ToString();
                    du.Obrisan = bool.Parse(row["Obrisan"].ToString());
                    du.Cena = int.Parse(row["Cena"].ToString());
                    DodatneUsluge.Add(du);

                }
                return DodatneUsluge;
            }
        }
        public static DodatnaUsluga Create(DodatnaUsluga du)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ToString()))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = $"INSERT INTO DodatnaUsluga (Naziv,Obrisan,Cena) VALUES (@Naziv,@Obrisan,@Cena);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                
                cmd.Parameters.AddWithValue("Naziv", du.Naziv);
                cmd.Parameters.AddWithValue("Obrisan", du.Obrisan);
                cmd.Parameters.AddWithValue("Cena", du.Cena);

                int newId = int.Parse(cmd.ExecuteScalar().ToString());   // izvrsava query
                du.Id = newId;
            }
            Projekat.Instance.dodaci.Add(du);
            return du;
        }
        public static void Update(DodatnaUsluga du)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ToString()))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE DodatnaUsluga SET Naziv=@Naziv,Obrisan=@Obrisan,Cena=@Cena WHERE Id=@Id";
                cmd.Parameters.AddWithValue("Naziv", du.Naziv);
                cmd.Parameters.AddWithValue("Obrisan", du.Obrisan);
                cmd.Parameters.AddWithValue("Cena", du.Cena);

                cmd.ExecuteNonQuery();

                foreach (var DodatnaUsluga in Projekat.Instance.dodaci)
                {
                    if (DodatnaUsluga.Id == du.Id)
                    {
                        DodatnaUsluga.Naziv = du.Naziv;
                        DodatnaUsluga.Obrisan = du.Obrisan;
                        DodatnaUsluga.Cena = du.Cena;
                        break;
                    }
                }
            }
        }
        public static void Delete(DodatnaUsluga du)
        {
            du.Obrisan = true;
            Update(du);
        }
        #endregion
    }
}