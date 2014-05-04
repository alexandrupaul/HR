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

        private BusinessLogic.BusinessLogic bl = new BusinessLogic.BusinessLogic();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                var studiiTable = bl.Citeste("getStudii");
                gridStudii.DataSource = studiiTable;
                gridStudii.DataBind();
            }
        }

        protected void btnAdaugaStudiu_Click(object sender, EventArgs e)
        {
          

            int nivel = 0;
            Int32.TryParse( txtNivelStudii.Text, out nivel);
            lblStudii.Text = 
                bl.AdaugaStudiu(new Entities.Entities.Studii() { 
                    DenumireStudii= txtDenumireStudii.Text, 
                    Nivel=nivel, 
                    ScutireImpozit = chkScutireImpozit.Checked 
                }) ? "Studiul a fost adaugat." : "Studiul nu a putut fi adaugat.";
        }

        protected void btnFiltreazaStudii_Click(object sender, EventArgs e)
        {
            List<Utils.Procedure.Parameter> lst = new List<Utils.Procedure.Parameter>();
            lst.Add(new Utils.Procedure.Parameter() { Key = "@Denumire_studii", Value = txtFiltruStudii.Text });
            gridStudii.DataSource = bl.Citeste("getStudii", lst);
            gridStudii.DataBind();
        }
    }

}