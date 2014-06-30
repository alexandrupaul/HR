using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ResurseUmane
{
    public partial class Delete : System.Web.UI.Page
    {
        private string Type;
        private string Id;

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Ref.Value = Request.UrlReferrer.ToString();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Id = Request.QueryString["id"].ToString(); // rand 
            this.Type = Request.QueryString["type"].ToString(); //tabela
        }

        protected void btnConfirmDelete_Click(object sender, EventArgs e)
        {
            ClientScriptManager cs = Page.ClientScript;
            string mesaj = new BusinessLogic.BusinessLogic().StergeEntitate(this.Id, this.Type) ? "Inregistrarea a fost stearsa!" :
                "Inregistrarea nu a putut fi stearsa. Va rugam sa incercati din nou";
            cs.RegisterClientScriptBlock(this.GetType(), "confirm", 
                string.Format(@"(function(){{window.alert('{0}');window.location.href='{1}';}})()", mesaj, Ref.Value), true);
        }

        protected void btnGoBack_Click(object sender, EventArgs e)
        {
            ClientScriptManager cs = Page.ClientScript;
            cs.RegisterClientScriptBlock(this.GetType(), "redirect", string.Format("(function(){{window.location.href='{0}';}})()", Ref.Value), true);
        }
    }

    public static class Ref
    {
        public static string Value;
    }
}