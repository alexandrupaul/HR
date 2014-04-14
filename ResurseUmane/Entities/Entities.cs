using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResurseUmane.Entities
{
    public class Entities
    {
        public class Banca
        {
            public string NumeBanci { get; set; }
            public decimal Comision { get; set; }
        }

        public class Angajat
        {
            public int MarcaAngajati {get;set;}
            public int CNP{get;set;}
            public string Nume {get;set;}
            public string Prenume{get;set;}
            public string Adresa {get;set;}
            public string Nationalitate{get;set;}
            public string Telefon{get;set;}
            public DateTime DataNasterii{get;set;}
            public DateTime DataAngajare{get;set;}
            public DateTime DataIncheiereContract{get;set;}
            public char Gen{get;set;}
            public  string IBAN {get;set;}
            public string Banca{get;set;}
	        
	
        }

        public class Orase
        {
            public string DenumireOrase { get; set; }
        }

        public class Studii
        {
            public string DenumireStudii { get; set; }
            public int Nivel { get; set; }
        }

        public class Functii
        {
            public string DenumireFunctii { get; set; }
        }
    }
}