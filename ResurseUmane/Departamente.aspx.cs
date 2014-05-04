using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ResurseUmane
{
    public partial class Departamente : System.Web.UI.Page
    {
        private BusinessLogic.BusinessLogic bl = new BusinessLogic.BusinessLogic();
        private DataTable dtDepartamente;

        protected void Page_PreInit(object sender, EventArgs e)
        {
            var departamenteTable = bl.Citeste("getDepartamente");
            dtDepartamente = departamenteTable;
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                gridDepartamente.DataSource = dtDepartamente;
                gridDepartamente.DataBind();
            }
        }

        protected void btnAdaugaDepartament_Click(object sender, EventArgs e)
        {
            int marcaManager = 0;
            Int32.TryParse(txtMarcaManager.Text, out marcaManager);

            lblDepartament.Text = bl.AdaugaDepartament(new Entities.Entities.Departamente() 
            { 
                Denumire_dpt = txtNumeDepartament.Text, 
                Marca_manager = marcaManager 
            }) ?"Departamentul a fost adaugat." : "Departamentul nu a putut fi adaugat.";
        }

        protected void gridDepartamente_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Response.Write(e.CommandArgument);
            int rowNumber = Int32.Parse(e.CommandArgument.ToString());
            DataRow dr = dtDepartamente.Rows[rowNumber];
        }
    }
}