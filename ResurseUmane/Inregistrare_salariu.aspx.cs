using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ResurseUmane
{
    public partial class Inregistreaza_salariu : System.Web.UI.Page
    {

        private BusinessLogic.BusinessLogic bl = new BusinessLogic.BusinessLogic();


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

        protected void btnAdaugaSalariu_Click(object sender, EventArgs e)
        {
            double brut = 0;
            Double.TryParse(txtSalariuBrut.Text, out brut);
            DateTime dataSalariu;
            DateTime.TryParse(txtDataPlata.Value, out dataSalariu);
            int marcaAngajat = 0;
            Int32.TryParse(dropMarcaAngajat.SelectedItem.Value,out marcaAngajat);

            lblSalarii.Text = bl.AdaugaSalariu(new Entities.Entities.Salarii()
            {
                MarcaAngajat = marcaAngajat,
                SalariuBrut = brut,
                DataSalariu = dataSalariu

            });
        }
    }
}