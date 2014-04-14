using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ResurseUmane
{
    public partial class Angajati : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnAdaugaAngajat_Click(object sender, EventArgs e)
        {
            var bl = new BusinessLogic.BusinessLogic();

            int marcaAngajat=0;
            Int32.TryParse(txtMarcaAngajat.Text,out marcaAngajat);
            int _CNP=0;
            Int32.TryParse(txtCNP.Text,out _CNP);
            //string Nume
            //string Prenume
            //string Adresa 
            //string Nationalitate
            //string Telefon
            DateTime dataNasterii;
            DateTime.TryParse(txtDataNasterii.Value, out dataNasterii);
            DateTime dataAngajare;
            DateTime.TryParse(txtDataAngajare.Value, out dataAngajare);
            DateTime dataIncheiereContract;
            DateTime.TryParse(txtDataIncheiereContract.Value, out dataIncheiereContract);
            char gen;
            Char.TryParse(txtGen.Text, out gen);
            //string IBAN ;
            //string Banca;

            lblAngajat.Text = bl.AdaugaAngajat(new Entities.Entities.Angajat()
            {
                MarcaAngajati = marcaAngajat,
                CNP = _CNP,
                Nume = txtNume.Text,
                Prenume = txtPrenume.Text,
                Adresa = txtAdresa.Text,
                Nationalitate = txtNationalitate.Text,
                Telefon = txtTelefon.Text,
                DataNasterii = dataNasterii,
                DataAngajare = dataAngajare,
                DataIncheiereContract = dataIncheiereContract,
                Gen = gen,
                IBAN = txtIBAN.Text,
                Banca = txtBanca.Text
            }) ? "Angajatul a fost adaugat." : "Angajatul nu a putut fi adaugat.";

            
            //lblBanci .Text = bl.AdaugaBanca(new Entities.Entities.Banca() { NumeBanci = txtNumeBanci.Text, Comision = comision }) ?
            //"Banca a fost adaugata." : "Banca nu a putut fi adaugata.";
            
        }
    }
}