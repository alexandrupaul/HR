using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ResurseUmane
{
    public partial class Inregistrare_concediu : System.Web.UI.Page
    {

        
        private BusinessLogic.BusinessLogic bl = new BusinessLogic.BusinessLogic();
        //private DataTable dtConcediu;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                getDropDownNumeAngajati();
            }
        }

        protected void getDropDownNumeAngajati()
        {
            
            var angajatiList = bl.Citeste("getAngajatiList");

            foreach (DataRow row in angajatiList.Rows)
            {
                dropMarcaAngajat.Items.Add(new ListItem(row.ItemArray[1].ToString() + " " + row.ItemArray[2].ToString(), row.ItemArray[0].ToString()));
            }
        }

       

        protected void btnAlocaConcediu_Click(object sender, EventArgs e)
        {
            DateTime dataStart;
            DateTime.TryParse(txtDataStart.Value, out dataStart);
            DateTime dataEnd;
            DateTime.TryParse(txtDataEnd.Value, out dataEnd);
            
            
            int nrZile= Convert.ToInt32(dataEnd.Subtract(dataStart).TotalDays);


            lblAlocaConcedii.Text = bl.AdaugaConcediu(new Entities.Entities.AlocareConcedii()
            {
                MarcaAngajat = Convert.ToInt32(dropMarcaAngajat.SelectedValue),
                DataStart = dataStart,
                DataEnd = dataEnd,
                NrZile = nrZile
            });
        }
    }
}