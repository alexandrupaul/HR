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
            public long CNP{get;set;}
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
            public int Id_banca{get;set;}
            public int Id_orase { get; set;}
	
        }

        public class Orase
        {
            public string DenumireOrase { get; set; }
        }

        public class Studii
        {
            public string DenumireStudii { get; set; }
            public int Nivel { get; set; }
            public bool ScutireImpozit { get; set; }
        }

        public class Functii
        {
            public string DenumireFunctii { get; set; }
        }

        public class Departamente
        {
            public string Denumire_dpt { get; set; }
            public int Marca_manager { get; set; }
        }

        public class Concedii
        {
            public int An { get; set; }
            public int TotalZile { get; set; }
            public int ZileRamase { get; set; }
            public int MarcaAngajat { get; set; }
        }

        public class AlocareConcedii
        {
            public int MarcaAngajat { get; set; }
            public DateTime DataStart { get; set; }
            public DateTime DataEnd { get; set; }
            public int NrZile { get; set; }
        }

        public class Salarii
        {
            public int MarcaAngajat { get; set; }
            public double SalariuBrut { get; set; }
            public DateTime DataSalariu { get; set; }
        }
    }
}