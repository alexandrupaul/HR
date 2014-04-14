using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ResurseUmane.Entities;
using ResurseUmane.Utils;
using System.Data.SqlClient;


namespace ResurseUmane.BusinessLogic
{
    public class BusinessLogic
    {
        public bool AdaugaBanca(Entities.Entities.Banca banca)
        {
            return new Procedure("dbo.insertBanci")
                .AddParameter("@Name", banca.NumeBanci)
                .AddParameter("@Cms", banca.Comision)
                .ExecuteNonQuery() != 0;
        }

        public bool AdaugaAngajat (Entities.Entities.Angajat angajat)
        {
            return new Procedure("dbo.insertAngajati")
                .AddParameter("@Marca_angajati", angajat.MarcaAngajati)
                .AddParameter("@CNP", angajat.CNP)
                .AddParameter("@Nume", angajat.Nume)
                .AddParameter("@Prenume", angajat.Prenume)
                .AddParameter("@Adresa", angajat.Adresa)
                .AddParameter("@Nationalitate", angajat.Nationalitate)
                .AddParameter("@Telefon", angajat.Telefon)
                .AddParameter("@Data_nasterii", angajat.DataNasterii)
                .AddParameter("@Data_angajare", angajat.DataAngajare)
                .AddParameter("@Data_incheiere_contract", angajat.DataIncheiereContract)
                .AddParameter("@Gen", angajat.Gen)
                .AddParameter("@IBAN", angajat.IBAN)
                .AddParameter("@Banca", angajat.Banca)
                .ExecuteNonQuery() != 0;
            
        }

        public bool AdaugaOras(Entities.Entities.Orase oras)
        {
            return new Procedure("dbo.insertOrase").AddParameter("@Denumire_orase", oras.DenumireOrase).ExecuteNonQuery() != 0;
        }

        public bool AdaugaStudiu(Entities.Entities.Studii studiu)
        {
            return new Procedure("dbo.insertStudii").AddParameter("@Denumire_studii", studiu.DenumireStudii)
                                                    .AddParameter("@Nivel", studiu.Nivel)
                                                    .ExecuteNonQuery() != 0;
        }

        public bool AdaugaFunctie(Entities.Entities.Functii functie)
        {
            return new Procedure("dbo.insertFunctii").AddParameter("@Denumire", functie.DenumireFunctii).ExecuteNonQuery() != 0;
        }

    }
}