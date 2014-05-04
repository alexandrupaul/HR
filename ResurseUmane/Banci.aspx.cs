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

        private BusinessLogic.BusinessLogic bl = new BusinessLogic.BusinessLogic();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var banciTable = bl.Citeste("getBanci");
                gridBanci.DataSource = banciTable;
                gridBanci.DataBind();
            }

        }

        protected void btnAdaugaBanca_Click(object sender, EventArgs e)
        {
            decimal comision = 0;
            Decimal.TryParse(txtComision.Text, out comision);
            lblBanci.Text = bl.AdaugaBanca(new Entities.Entities.Banca() { NumeBanci = txtNumeBanci.Text, Comision = comision }) ?
            "Banca a fost adaugata." : "Banca nu a putut fi adaugata.";


        }

        protected void btnFiltreazaBanci_Click(object sender, EventArgs e)
        {
            List<Utils.Procedure.Parameter> lst = new List<Utils.Procedure.Parameter>();
            lst.Add(new Utils.Procedure.Parameter() { Key = "@Nume_banci", Value = txtFiltruBanci.Text });
            gridBanci.DataSource = bl.Citeste("getBanci", lst);
            gridBanci.DataBind();
        }
    }
}