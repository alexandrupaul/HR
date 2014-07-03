using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ResurseUmane.Entities;
using ResurseUmane.Utils;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


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
                .AddParameter("@ID_banca", angajat.Id_banca)
                .AddParameter("@ID_orase",angajat.Id_orase)
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
                                                    .AddParameter("@Has_scutire_impozit", studiu.ScutireImpozit)
                                                    .ExecuteNonQuery() != 0;
        }

        public bool AdaugaFunctie(Entities.Entities.Functii functie)
        {
            return new Procedure("dbo.insertFunctii").AddParameter("@Denumire", functie.DenumireFunctii).ExecuteNonQuery() != 0;
        }


        public bool AdaugaDepartament(Entities.Entities.Departamente departament)
        {
            return new Procedure("dbo.insertDepartamente").AddParameter("@Denumire_dpt", departament.Denumire_dpt)
                                                          .AddParameter("@Marca_manager", departament.Marca_manager)
                                                          .ExecuteNonQuery() != 0;
        }

        public bool AdaugaConcediuAngajat(Entities.Entities.Concedii concediuAngajat)
        {
            return new Procedure("dbo.InsertConcediiAngajati").AddParameter("@An", concediuAngajat.An)
                                                             .AddParameter("@Total_zile", concediuAngajat.TotalZile)
                                                             .AddParameter("@Zile_ramase", concediuAngajat.ZileRamase)
                                                             .AddParameter("@Marca_angajat", concediuAngajat.MarcaAngajat)
                                                             .ExecuteNonQuery()!=0;
        }


        public string AdaugaConcediu(Entities.Entities.AlocareConcedii concediu)
        {
            return new Procedure("dbo.insertConcedii").AddParameter("@Marca_angajat", concediu.MarcaAngajat)
                                                       .AddParameter("Data_start", concediu.DataStart)
                                                       .AddParameter("Data_end", concediu.DataEnd)
                                                       .AddParameter("Nr_zile", concediu.NrZile)
                                                       .ExecuteScalar();
        }

        public bool AdaugaSalariu(Entities.Entities.Salarii salariu)
        {
            return new Procedure("dbo.insertSalarii").AddParameter("@Brut", salariu.SalariuBrut)
                                                     .AddParameter("@Data_plata", salariu.DataSalariu)
                                                     .ExecuteNonQuery() != 0;
            
        }


        public DataTable Citeste(string numeProc, List<Procedure.Parameter> parametri = null)
        {
            var proc = new Procedure(numeProc);

            if (parametri != null && parametri.Count > 0)
            {
                proc.AddParameter(parametri);
            }

            return proc.ExecuteDataTable();
        }


        public DataTable EditeazaEntitate(string id, string type)
        {
            var proc = new Procedure("dbo.editEntitati").AddParameter("@ID", id).AddParameter("@Type", type);
            return proc.ExecuteDataTable();
        }

        public bool StergeEntitate(string id, string type)
        {
            return new Procedure("dbo.stergeEntitati").AddParameter("@ID", id).AddParameter("@Type", type).ExecuteNonQuery()!=0;
        }

        public List<string> ListParams(string procName)
        {
            List<string> paramList = new List<string>();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql_Prod"].ConnectionString);
            SqlCommand cmd = new SqlCommand(procName, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();
            SqlCommandBuilder.DeriveParameters(cmd);


            foreach (SqlParameter p in cmd.Parameters)
            {
                paramList.Add(p.ParameterName);
            }
            return paramList;
        }

        

    }
}