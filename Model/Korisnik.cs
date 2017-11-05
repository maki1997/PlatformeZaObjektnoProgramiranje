using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace POP_12.Model
{
    [Serializable]
    public enum TipKorisnika {
        Administrator,
        Prodavac
    }
    public class Korisnik
    {

        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }
        public string Sifra { get; set; }
        public bool Obrisan { get; set; }
    }
}