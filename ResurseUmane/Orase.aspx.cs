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
    public partial class Orase : System.Web.UI.Page
    {

        private BusinessLogic.BusinessLogic bl = new BusinessLogic.BusinessLogic();
        private DataTable dtOrase;

        protected void Page_PreInit(object sender, EventArgs e)
        {
            var oraseTable = bl.Citeste("getOrase");
            dtOrase = oraseTable;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //var oraseTable = bl.Citeste("getOrase");
                gridOrase.DataSource = dtOrase;
                gridOrase.DataBind();
            }
        }

        protected void btnAdaugaOras_Click(object sender, EventArgs e)
        {
            lblOrase.Text = bl.AdaugaOras(new Entities.Entities.Orase() { DenumireOrase=txtDenumireOras.Text }) ?
            "Orasul a fost adaugat." : "Orasul nu a putut fi adaugat.";
        }

        protected void gridOrase_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Response.Write(e.CommandArgument);
            int rowNumber = Int32.Parse(e.CommandArgument.ToString());
            GridViewRow gdrow = gridOrase.Rows[rowNumber];
            var file = e.CommandName == "EditRow" ? "Edit.aspx" : "Delete.aspx";
            string str = Path.GetFileName(Request.PhysicalPath).ToString();
            Response.Redirect(file + "?ID=" + Convert.ToInt32(gdrow.Cells[2].Text) + "&Type=" + str.Substring(0, str.IndexOf('.')).ToLower());
        }
    }
}