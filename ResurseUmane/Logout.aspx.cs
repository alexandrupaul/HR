using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ResurseUmane
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            new Security(Session, Server, Response, Request, "http://localhost/HrApp/Default.aspx").Logout();
        }
    }
}