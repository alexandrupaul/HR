using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace ResurseUmane
{
    public partial class Angajati : System.Web.UI.Page
    {
        private BusinessLogic.BusinessLogic bl = new BusinessLogic.BusinessLogic();
        private DataTable dtAngajati;

        protected void Page_PreInit(object sender, EventArgs e)
        {
            var angajatiTable = bl.Citeste("getAngajati");
            dtAngajati = angajatiTable;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //var angajatiTable = bl.Citeste("getAngajati");
                gridAngajati.DataSource = dtAngajati;
                gridAngajati.DataBind();

                var oraseList = bl.Citeste("getOraseList");
                dropDownOrase.DataSource = oraseList;
                dropDownOrase.DataTextField = oraseList.Columns[1].ToString();
                dropDownOrase.DataValueField = oraseList.Columns[0].ToString();
                dropDownOrase.DataBind();

                var banciList = bl.Citeste("getBanciList");
                dropDownBanca.DataSource = banciList;
                dropDownBanca.DataTextField = banciList.Columns[1].ToString();
                dropDownBanca.DataValueField = banciList.Columns[0].ToString();
                dropDownBanca.DataBind();
            }


           


        }
        protected void btnAdaugaAngajat_Click(object sender, EventArgs e)
        {
            

            int marcaAngajat=0;
            Int32.TryParse(txtMarcaAngajat.Text,out marcaAngajat);
            long _CNP=0;
            Int64.TryParse(txtCNP.Text,out _CNP);
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
            Char.TryParse(dropDownGen.SelectedValue, out gen);
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
                Id_banca = Convert.ToInt32(dropDownBanca.SelectedItem.Value),
                Id_orase= Convert.ToInt32(dropDownOrase.SelectedItem.Value)
            }) ? "Angajatul a fost adaugat." : "Angajatul nu a putut fi adaugat.";

            
            
            
        }


        protected void btnFiltreazaAngajati_Click(object sender, EventArgs e)
        {
            List<Utils.Procedure.Parameter> lst = new List<Utils.Procedure.Parameter>();
            if (!String.IsNullOrEmpty(txtFiltruCnp.Text))
            {
                lst.Add(new Utils.Procedure.Parameter() { Key = "@Cnp", Value = txtFiltruCnp.Text });
            }
            if (!String.IsNullOrEmpty(txtFiltruNume.Text))
            {
                lst.Add(new Utils.Procedure.Parameter() { Key = "@Nume", Value = txtFiltruNume.Text });
            }
            if (!String.IsNullOrEmpty(txtFiltruPrenume.Text))
            {
                lst.Add(new Utils.Procedure.Parameter() { Key = "@Prenume", Value = txtFiltruPrenume.Text });
            }
            if (!String.IsNullOrEmpty(dataAngajareStart.Value))
            {
                lst.Add(new Utils.Procedure.Parameter() { Key = "@Data_angajare_start", Value = dataAngajareStart.Value });
            }
            if (!String.IsNullOrEmpty(dataAngajareEnd.Value))
            {
                lst.Add(new Utils.Procedure.Parameter() { Key = "@Data_angajare_end", Value = dataAngajareEnd.Value });
            } 
            gridAngajati.DataSource = bl.Citeste("getAngajati", lst);
            gridAngajati.DataBind();
        }

        protected void gridAngajati_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowNumber = Int32.Parse(e.CommandArgument.ToString());
            GridViewRow gdrow = gridAngajati.Rows[rowNumber]; 
            var file = e.CommandName == "EditRow" ? "Edit.aspx" : "Delete.aspx";
            string str = Path.GetFileName(Request.PhysicalPath).ToString();
            Response.Redirect(file + "?ID=" + Convert.ToInt32(gdrow.Cells[2].Text) + "&Type=" + str.Substring(0, str.IndexOf('.')).ToLower());
        }
    }
}