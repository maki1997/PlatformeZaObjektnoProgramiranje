using POP_12.Model;
using POP_12.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_12.Model
{

}
public class Program
{
    static List<Namestaj> Namestaj { get; set; } = new List<Namestaj>();
    static void Main(string[] args)
    {
        Salon s1 = new Salon()
        {
            Id = 1,
            Naziv = "Forma FTNale",
            Adresa = "Trg Dositeja Obradovica 6",
            BrojZiroRacuna = "840-000768666-83",
            Email = "kontat@uns.ftn.ac.rs",
            PIB = 33556489,
            MaticniBroj = 2509997760031,
            Telefon = "021/224-446",
            Websajt = "http://www.ftn.uns.ac.rs"
        };

        var sofaTipNamestaja = new TipNamestaja()
        {
            id = 1,
            Naziv = "sofa",
        };

        Namestaj.Add(new Namestaj()
        {
            Id = 1,
            JedinicnaCena = 28,
            Naziv = "sofa123",
            KolicinaUMagacinu = 2,
            Akcija = null

        });

        Console.WriteLine($"Dobrodosli u salon namestaja { s1.Naziv }.");
        IspisiGlavniMeni();
        Console.ReadLine();

    }
    private static void IspisiGlavniMeni()
    {
        int izbor = 0;

        do
        {
            Console.WriteLine("===== GLAVNI MENI =====");
            Console.WriteLine("1. Rad sa namestajem");
            Console.WriteLine("2. Rad sa tipom");
            Console.WriteLine("3. Rad sa prodajom namestaja");
            Console.WriteLine("4. Rad sa akcijama");
            Console.WriteLine("0. Izlaz iz aplikacije");

        } while (izbor < 0 || izbor > 4);

        izbor = int.Parse(Console.ReadLine());

        switch (izbor)
        {
            case 1:
                IspisiMeniNamestaja();
                break;
            case 2:
                IspisiMeniTipaNamestaja();
                break;
            case 0:
                Environment.Exit(0);
                break;
            default:
                break;
        }
    }
    private static void IspisiMeniNamestaja()
    {
        int izbor = 0;

        do
        {
            Console.WriteLine("===== NAMESTAJ =====");
            Console.WriteLine("1. Listing namestaja");
            Console.WriteLine("2. Dodaj novi namestaj");
            Console.WriteLine("3. Izmeni postojeci namestaj");
            Console.WriteLine("4. Obrisi postojeci namestaj");
            Console.WriteLine("0. Povratak na glavni meni");

        } while (izbor < 0 || izbor > 4);

        switch (izbor)
        {
            case 1:
                IzlistajNamestaj();
                break;
            case 2:
                DodajNamestaj();
                break;
            case 3:
                IzmeniNamestaj();
                break;
            case 4:
                ObrisiNamestaj();
                break;
            case 0:
                IspisiGlavniMeni();
                break;
            default:
                break;
        }

    }

    private static void IzlistajNamestaj()
    {
        int index = 0;
        Console.WriteLine("===== LISTING NAMESTAJA =====");

        foreach (var namestaj in Namestaj)
        {
            Console.WriteLine($"{ ++index}. {namestaj.Naziv}, cena: {namestaj.JedinicnaCena}");
        }
    }

    private static void DodajNamestaj()
    {
        throw new NotImplementedException();
    }

    private static void IzmeniNamestaj()
    {
        throw new NotImplementedException();
    }

    private static void ObrisiNamestaj()
    {
        throw new NotImplementedException();
    }

    private static void IspisiMeniTipaNamestaja()
    {
        int izbor = 0;
        do
        {
            Console.WriteLine("==== TIP NAMESTAJA ====");
            Console.WriteLine("1. Listing tipa namestaja");
            Console.WriteLine("2. Dodaj tip namestaja");
            Console.WriteLine("3. Izmeni postojeci tip namestaja");
            Console.WriteLine("4. Obrisi postojeci tip namestaja");
            Console.WriteLine("0. Izadji");

        } while (izbor < 0 || izbor > 4);

        izbor = int.Parse(Console.ReadLine());
        switch (izbor)
        {
            case 1:
                IzlistajTipNamestaja();
                break;
            case 2:
                DodajTipNamestaja();
                break;
            case 3:
                IzmeniTipNamestaja();
                break;
            case 4:
                ObrisiTipNamestaja();
                break;
            case 0:
                IspisiGlavniMeni();
                break;
            default:
                break;

        }

    }
    private static void IzlistajTipNamestaja()
    {
        throw new NotImplementedException();
    }
    private static void DodajTipNamestaja()
    {
        throw new NotImplementedException();
    }

    private static void IzmeniTipNamestaja()
    {
        throw new NotImplementedException();
    }

    private static void ObrisiTipNamestaja()
    {
        throw new NotImplementedException();
    }

    private static bool Logovanje(String id, String pass)
    {
        List<Korisnik> lk = GenericSerializer.Deserialize<Korisnik>("korisnik.xml");
        foreach (var k in lk)
        {
            if (id == k.KorisnickoIme && pass == k.Sifra)
                return true;
        }
        return false;
    }
    private static void LogovanjeMeni()
    {

        Console.WriteLine("Molimo vas da se ulogujete!");
        Console.WriteLine("Unesite vase korisnicko ime:");
        String naziv = Console.ReadLine();
        Console.WriteLine("Unesite sifru:");
        String sifra = Console.ReadLine();
        bool odg = Logovanje(naziv, sifra);
        if (odg == true)
            IspisiGlavniMeni();
        else
        {
            Console.WriteLine("Niste dobro uneli korisnicko ime ili sifru!");
            LogovanjeMeni();
        }
    }
}
// izmena,dodavanje, trazi po nazivu tipa 