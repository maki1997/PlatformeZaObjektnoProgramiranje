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
    public class AkcijskaProdaja : INotifyPropertyChanged
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
        private DateTime dp;
        public DateTime DatumPocetka
        {
            get { return dp; }
            set { dp = value; OnPropertyChanged("DatumPocetka"); }
        }
        private DateTime dk;
        public DateTime DatumKraja
        {
            get { return dk; }
            set { dk = value; OnPropertyChanged("DatumKraja"); }
        }
        private int popust;
        public int Popust
        {
            get { return popust; }
            set { popust = value; OnPropertyChanged("Popust"); }
        }
        private bool obrisan;
        public bool Obrisan
        {
            get { return obrisan; }
            set { obrisan = value; OnPropertyChanged("Obrisan"); }
        }


        public static AkcijskaProdaja GetById(int id)
        {
            foreach (var Akcija in Projekat.Instance.akcija)
            {
                if (Akcija.Id == id)
                {
                    return Akcija;
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
        public override string ToString()
        {


            return $"Popust: {Popust} \n Datum pocetka:{DatumPocetka} \n Datum kraja{DatumKraja}";
        }
        #region Database
        public static ObservableCollection<AkcijskaProdaja> GetAll()
        {
            var Akcije = new ObservableCollection<AkcijskaProdaja>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM AkcijskaProdaja WHERE Obrisan=0";

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = cmd;
                da.Fill(ds, "AkcijskaProdaja"); // Query se izvrsava
                foreach (DataRow row in ds.Tables["AkcijskaProdaja"].Rows)
                {
                    var ap = new AkcijskaProdaja();
                    ap.Id = int.Parse(row["Id"].ToString());
                    ap.DatumPocetka = DateTime.Parse(row["DatumPocetka"].ToString());
                    ap.DatumKraja = DateTime.Parse(row["DatumKraja"].ToString());
                    ap.Obrisan = bool.Parse(row["Obrisan"].ToString());
                    Akcije.Add(ap);

                }
                return Akcije;
            }
        }
        public static AkcijskaProdaja Create(AkcijskaProdaja ap)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ToString()))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = $"INSERT INTO AkcijskaProdaja (DatumPocetka,DatumKraja,Obrisan) VALUES (@DatumPocetka,@DatumKraja,@Obrisan);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";

                cmd.Parameters.AddWithValue("DatumPocetka", ap.DatumPocetka);
                cmd.Parameters.AddWithValue("DatumKraja", ap.DatumKraja);
                cmd.Parameters.AddWithValue("Obrisan", ap.Obrisan);

                int newId = int.Parse(cmd.ExecuteScalar().ToString());   // izvrsava query
                ap.Id = newId;
            }
            Projekat.Instance.akcija.Add(ap);
            return ap;
        }
        public static void Update(AkcijskaProdaja ap)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ToString()))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE AkcijskaProdaja SET DatumPocetka=@DatumPocetka,DatumKraja=@DatumKraja,Obrisan=@Obrisan WHERE Id=@Id";
                cmd.Parameters.AddWithValue("DatumPocetka", ap.DatumPocetka);
                cmd.Parameters.AddWithValue("DatumKraja", ap.DatumKraja);
                cmd.Parameters.AddWithValue("Obrisan", ap.Obrisan);


                cmd.ExecuteNonQuery();

                foreach (var AkcijskaProdaja in Projekat.Instance.akcija)
                {
                    if (AkcijskaProdaja.Id == ap.Id)
                    {
                        AkcijskaProdaja.DatumPocetka = ap.DatumPocetka;
                        AkcijskaProdaja.DatumKraja = ap.DatumKraja;
                        AkcijskaProdaja.Obrisan = ap.Obrisan;
                        break;
                    }
                }
            }
        }
        public static void Delete(AkcijskaProdaja ap)
        {
            ap.Obrisan = true;
            Update(ap);
        }
        #endregion

    }
}
