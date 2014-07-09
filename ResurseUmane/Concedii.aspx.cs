using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;

namespace ResurseUmane
{
    public partial class Concedii : System.Web.UI.Page
    {

        private BusinessLogic.BusinessLogic bl = new BusinessLogic.BusinessLogic();
        private DataTable dtConcediiAngajati;

        protected void Page_PreInit(object sender, EventArgs e)
        {

            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getDropDownAniConcediu();
                getDropDownNumeAngajati();

            }
        }

        protected void getDropDownAniConcediu()
        {
            dropDownAn.Items.Insert(0, "Select");
            var list = new Utils.Procedure("dbo.getAniConcediiAngajati").ExecuteDataTable(); ;
            foreach (DataRow row in list.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    dropDownAn.Items.Add(new ListItem(item.ToString()));
                }
            }
        }

        

        protected void getDropDownNumeAngajati()
        {
            var angajatiList = bl.Citeste("getAngajatiList");
            
            foreach (DataRow row in angajatiList.Rows)
            {   
                    dropMarcaAngajat.Items.Add(new ListItem (row.ItemArray[1].ToString()+" "+row.ItemArray[2].ToString(),row.ItemArray[0].ToString()));
            }
        }



        protected void btnAdaugaConcediu_Click(object sender, EventArgs e)
        {
            
            
            int _An = 0;
            Int32.TryParse(txtAn.Text, out _An);
            int totalZile = 0;
            Int32.TryParse(txtTotalZile.Text, out totalZile);
            int zileRamase = 0;
            Int32.TryParse(txtZileRamase.Text, out zileRamase);
           
            lblConcedii.Text = bl.AdaugaConcediuAngajat(new Entities.Entities.Concedii()
            {
                An=_An,
                TotalZile=totalZile,
                ZileRamase=zileRamase,
                MarcaAngajat = Convert.ToInt32(dropMarcaAngajat.SelectedItem.Value)

            });
        }


        protected void dropDownSelectedIndexChanged(object sender, EventArgs e)
        {
            dropDownAn.Items.Remove("Select");
            List<Utils.Procedure.Parameter> lst = new List<Utils.Procedure.Parameter>();
            lst.Add(new Utils.Procedure.Parameter() { Key = "@An", Value = Convert.ToInt32( dropDownAn.SelectedValue) });
            var concediiTable = bl.Citeste("getConcediiAngajati", lst);
            dtConcediiAngajati = concediiTable;
            gridConcedii.DataSource = dtConcediiAngajati;
            gridConcedii.DataBind();
        }

        protected void gridConcedii_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowNumber = Int32.Parse(e.CommandArgument.ToString());
            GridViewRow gdrow = gridConcedii.Rows[rowNumber];
            var file = e.CommandName == "EditRow" ? "Edit.aspx" : "Delete.aspx";
            string str = Path.GetFileName(Request.PhysicalPath).ToString();
            Response.Redirect(file + "?ID=" + Convert.ToInt32(gdrow.Cells[2].Text) + "&Type=" + str.Substring(0, str.IndexOf('.')).ToLower() + "_angajati");
        }
    }
}