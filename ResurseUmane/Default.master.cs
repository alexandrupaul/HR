using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ResurseUmane.BusinessLogic;
using ResurseUmane;
using System.Data;

namespace ResurseUmane
{
    public partial class Default1 : System.Web.UI.MasterPage
    {
        public List<string> rapoarte;
        protected void Page_Load(object sender, EventArgs e)
        {
            rapoarte = new List<string>();
            DataTable sqlRpt = new BusinessLogic.BusinessLogic().Citeste("dbo.getRapoarte");
            foreach (DataRow dr in sqlRpt.Rows)
            {
                rapoarte.Add(dr["name"].ToString());
            }

            Security sec = new Security(Session, Server, Response, Request, "http://localhost/HrApp/Default.aspx");
            if (sec.IsLoggedIn())
            {
                lblUsername.Text = sec.Username;
                lnkLogin.Visible = false;
            }
            else
            {
                lnkLogin.Visible = true;
                lblUsername.Visible = false;
            }
        }
    }
}