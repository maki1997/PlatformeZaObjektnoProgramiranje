using SF_12_2016.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF_12_2016.Model
{
    [Serializable]
    public class Salon
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string AdresaSajta { get; set; }
        public int PIB { get; set; }
        public int MaticniBroj { get; set; }
        public string BrojZiroRacuna { get; set; }

        #region Database
        public static ObservableCollection<Salon> GetAll()
        {
            var Salon = new ObservableCollection<Salon>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM Salon";

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = cmd;
                da.Fill(ds, "Salon"); // Query se izvrsava
                foreach (DataRow row in ds.Tables["Salon"].Rows)
                {
                    var s = new Salon();
                    s.Id = int.Parse(row["Id"].ToString());
                    s.Naziv = row["Naziv"].ToString();
                    s.Adresa = row["Adresa"].ToString();
                    s.Telefon = row["Telefon"].ToString();
                    s.Email = row["Email"].ToString();
                    s.AdresaSajta = row["AdresaSajta"].ToString();
                    s.PIB = int.Parse(row["PIB"].ToString());
                    s.MaticniBroj = int.Parse(row["MaticniBroj"].ToString());
                    s.BrojZiroRacuna = row["BrojZiroRacuna"].ToString();

                    Salon.Add(s);

                }
                return Salon;
            }
        }
            public static void Update(Salon s)
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

                foreach (var Salon in Projekat.Instance.saloni)
                {
                    if (Salon.Id == s.Id)
                    {

                        break;
                    }
                }
            }
        }
        #endregion

    }

}

