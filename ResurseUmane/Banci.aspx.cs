using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ResurseUmane.BusinessLogic;
using System.Data;
using System.IO;

namespace ResurseUmane
{
    public partial class Banci : System.Web.UI.Page
    {

        private BusinessLogic.BusinessLogic bl = new BusinessLogic.BusinessLogic();
        private DataTable dtBanci;

        protected void Page_PreInit(object sender, EventArgs e)
        {

            var banciTable = bl.Citeste("getBanci");
            dtBanci = banciTable;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
                gridBanci.DataSource = dtBanci;
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
        protected void gridBanci_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Response.Write(e.CommandArgument);
            int rowNumber = Int32.Parse(e.CommandArgument.ToString());
            GridViewRow gdrow = gridBanci.Rows[rowNumber];
            var file = e.CommandName == "EditRow" ? "Edit.aspx" : "Delete.aspx";
            string str = Path.GetFileName(Request.PhysicalPath).ToString();
            Response.Redirect(file + "?ID=" + Convert.ToInt32(gdrow.Cells[2].Text)+ "&Type=" + str.Substring(0, str.IndexOf('.')).ToLower());

        }
    }
}