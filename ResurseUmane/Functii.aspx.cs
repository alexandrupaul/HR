using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ResurseUmane
{
    public partial class Functii : System.Web.UI.Page
    {
        private BusinessLogic.BusinessLogic bl = new BusinessLogic.BusinessLogic();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var functiiTable = bl.Citeste("getFunctii");
                gridFunctii.DataSource = functiiTable;
                gridFunctii.DataBind();
            }
        }

        protected void btnAdaugaFunctie_Click(object sender, EventArgs e)
        { 
            lblFunctii.Text = bl.AdaugaFunctie(new Entities.Entities.Functii() { DenumireFunctii = txtDenumireFunctii.Text }) ?
            "Functia a fost adaugata." : "Functia nu a putut fi adaugata.";
        }
    }
}