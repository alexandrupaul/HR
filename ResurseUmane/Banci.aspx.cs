using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ResurseUmane.BusinessLogic;

namespace ResurseUmane
{
    public partial class Banci : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdaugaBanca_Click(object sender, EventArgs e)
        {
            var bl = new BusinessLogic.BusinessLogic();
            decimal comision = 0;
            Decimal.TryParse(txtComision.Text, out comision);
            lblBanci.Text = bl.AdaugaBanca(new Entities.Entities.Banca() { NumeBanci = txtNumeBanci.Text, Comision = comision }) ?
            "Banca a fost adaugata." : "Banca nu a putut fi adaugata.";
        }
    }
}