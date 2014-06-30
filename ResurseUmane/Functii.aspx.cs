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
    public partial class Functii : System.Web.UI.Page
    {
        private BusinessLogic.BusinessLogic bl = new BusinessLogic.BusinessLogic();
        private DataTable dtFunctii;


        protected void Page_PreInit(object sender, EventArgs e)
        {
            var functiiTable = bl.Citeste("getFunctii");
            dtFunctii = functiiTable;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //var functiiTable = bl.Citeste("getFunctii");
                gridFunctii.DataSource = dtFunctii;
                gridFunctii.DataBind();
            }
        }

        protected void btnAdaugaFunctie_Click(object sender, EventArgs e)
        { 
            lblFunctii.Text = bl.AdaugaFunctie(new Entities.Entities.Functii() { DenumireFunctii = txtDenumireFunctii.Text }) ?
            "Functia a fost adaugata." : "Functia nu a putut fi adaugata.";
        }

        protected void gridFunctii_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Response.Write(e.CommandArgument);
            int rowNumber = Int32.Parse(e.CommandArgument.ToString());
            GridViewRow gdrow = gridFunctii.Rows[rowNumber];
            var file = e.CommandName == "EditRow" ? "Edit.aspx" : "Delete.aspx";
            string str = Path.GetFileName(Request.PhysicalPath).ToString();
            Response.Redirect(file + "?ID=" + Convert.ToInt32(gdrow.Cells[2].Text) + "&Type=" + str.Substring(0, str.IndexOf('.')).ToLower());
        }
    }
}