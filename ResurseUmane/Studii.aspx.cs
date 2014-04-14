using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ResurseUmane
{
    public partial class Studii : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdaugaStudiu_Click(object sender, EventArgs e)
        {
            var bl = new BusinessLogic.BusinessLogic();

            int nivel = 0;
            Int32.TryParse( txtNivelStudii.Text, out nivel);
            lblStudii.Text = bl.AdaugaStudiu(new Entities.Entities.Studii() { DenumireStudii= txtDenumireStudii.Text, Nivel=nivel }) ?
            "Studiul a fost adaugat." : "Studiul nu a putut fi adaugat.";
        }
    }
}