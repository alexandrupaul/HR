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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdaugaOras_Click(object sender, EventArgs e)
        {
            var bl = new BusinessLogic.BusinessLogic();
            
            lblOrase.Text = bl.AdaugaOras(new Entities.Entities.Orase() { DenumireOrase=txtDenumireOras.Text }) ?
            "Orasul a fost adaugat." : "Orasul nu a putut fi adaugat.";
        }
   

    }
}