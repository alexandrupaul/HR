using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ResurseUmane.BusinessLogic;

namespace ResurseUmane
{
    public partial class Rapoarte : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string numeRaport = Request.QueryString["rpt"].ToString();
            gridRapoarte.DataSource = new BusinessLogic.BusinessLogic().Citeste("dbo.rpt_"+numeRaport);
            gridRapoarte.DataBind();
            legendReport.InnerText = legendReport.InnerText +" : "+ numeRaport;
        }
    }
}