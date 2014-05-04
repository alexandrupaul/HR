using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ResurseUmane
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var id = Request.QueryString["id"].ToString(); // rand 
            var type = Request.QueryString["type"].ToString(); //tabela

            TextBox tx = new TextBox();
            tx.ID = "tx_test";
            tx.Text = type;
            panel_Form.Controls.Add(tx);

        }
    }
}