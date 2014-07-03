using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ResurseUmane
{
    public partial class Default : System.Web.UI.Page
    {
        private Security sec;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.sec = new Security(Session, Server, Response, Request, "http://localhost/HrApp/Default.aspx");
            if (sec.IsLoggedIn())
            {
                fldAuth.Visible = false;
                lblAuth.Visible = true;
            }
            else
            {
                fldAuth.Visible = true;
                lblAuth.Visible = false;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
           sec.Login(txtUsername.Text, txtPassword.Text);
        }
    }
}