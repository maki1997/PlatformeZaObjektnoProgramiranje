using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace POP_12.Model
{  
    public enum {
        Administrator,
        Prodavac
    }
    public class Class1
    {

        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public bool Obrisan { get; set; }
    }
}