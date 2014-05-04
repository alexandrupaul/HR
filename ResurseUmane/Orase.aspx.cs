using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ResurseUmane
{
    public partial class Orase : System.Web.UI.Page
    {

        private BusinessLogic.BusinessLogic bl = new BusinessLogic.BusinessLogic();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var oraseTable = bl.Citeste("getOrase");
                gridOrase.DataSource = oraseTable;
                gridOrase.DataBind();
            }
        }

        protected void btnAdaugaOras_Click(object sender, EventArgs e)
        {
            lblOrase.Text = bl.AdaugaOras(new Entities.Entities.Orase() { DenumireOrase=txtDenumireOras.Text }) ?
            "Orasul a fost adaugat." : "Orasul nu a putut fi adaugat.";
        }
   

    }
}