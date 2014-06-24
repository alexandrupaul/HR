using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Common;

namespace ResurseUmane
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var id = Request.QueryString["id"].ToString(); // rand 
            var type = Request.QueryString["type"].ToString(); //tabela
            var dtEntitate = new BusinessLogic.BusinessLogic().EditeazaEntitate(id, type);
            var dtFks = GetFKs(type);

            foreach (DataColumn dc in dtEntitate.Columns)
            {
                var fks = getLinks(dtFks, dc.ColumnName);
                Label lbl = new Label();
                lbl.Text = dc.ColumnName;
                panel_Form.Controls.Add(lbl);
                if (fks.by != null && fks.to != null)
                {
                    DropDownList dl = new DropDownList();
                    var values = new Utils.Procedure("getContents").AddParameter("@tableName", fks.to).ExecuteDataTable();
                    foreach (DataRow value in values.Rows)
                    {
                        dl.Items.Add(new ListItem(value[1].ToString(), value[0].ToString()));
                    }
                    panel_Form.Controls.Add(dl);
                }
                else
                {
                    TextBox tx = new TextBox();
                    tx.ID = "txt_" + dc.ColumnName;
                    tx.Text = dtEntitate.Rows[0][dc].ToString();
                    var typeStr = dc.DataType.ToString().Replace("System.", "").ToLower();
                    string inputType;
                    switch (typeStr)
                    {
                        case "string":
                            inputType = "text";
                            break;
                        case "datetime":

                            var date = DateTime.Parse(tx.Text);
                            tx.Text = date.ToString("yyyy-MM-dd");
                            inputType = "date";
                            tx.Attributes.Add("data-date", tx.Text);
                            break;
                        default:
                            inputType = "text";
                            break;
                    }
                    tx.Attributes.Remove("type");
                    tx.Attributes.Add("type", inputType);
                    panel_Form.Controls.Add(tx);
                }
            }

        }

        private DataTable GetFKs(string tableName)
        {
            return new Utils.Procedure("getLegaturi").AddParameter("@tableName", tableName).ExecuteDataTable();
        }

        private class FK {
            public string to {get;set;}
            public string by {get;set;}
        }

        private FK getLinks(DataTable fks, string columnName)
        {
            var fk = new FK();
            foreach (DataRow dr in fks.Rows)
            {
                if (dr["by"].ToString() == columnName)
                {
                    fk.by = dr["by"].ToString();
                    fk.to = dr["to"].ToString();
                }
            }

            return fk;
        }
    }
}