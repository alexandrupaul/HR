using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace ResurseUmane
{
    public partial class Edit : System.Web.UI.Page
    {
        
        public string ModelType;
        public string id;
        public string type;

        

        protected void Page_Load(object sender, EventArgs e)
        {
            

            id = Request.QueryString["id"].ToString(); // rand 
            type = ModelType = Request.QueryString["type"].ToString(); //tabela
            var dtEntitate = new BusinessLogic.BusinessLogic().EditeazaEntitate(id, type);
            var dtFks = GetFKs(type);

            foreach (DataColumn dc in dtEntitate.Columns)
            {
                var fks = getLinks(dtFks, dc.ColumnName);
                Label lbl = new Label();
                HtmlGenericControl row = new HtmlGenericControl("div");
                row.Attributes.Add("class", "edit-row");
                lbl.Text = dc.ColumnName;
                row.Controls.Add(lbl);
                if (fks.by != null && fks.to != null)
                {
                    DropDownList dl = new DropDownList();
                    dl.ID = "dl_" + dc.ColumnName;
                    var values = new Utils.Procedure("getContents").AddParameter("@tableName", fks.to).ExecuteDataTable();
                    foreach (DataRow value in values.Rows)
                    {
                        dl.Items.Add(new ListItem(value[1].ToString(), value[0].ToString()));
                    }
                    row.Controls.Add(dl);
                }
                else
                {
                    TextBox tx = new TextBox();
                    tx.ID = "txt_" + dc.ColumnName;
                    try
                    {
                        tx.Text = dtEntitate.Rows[0][dc].ToString();
                    }
                    catch (Exception ex)
                    {
                        var err = new HtmlGenericControl("h2");
                        err.InnerHtml = "A aparut o eroare. Va rugam sa reveniti";
                        panel_Form.Controls.Add(err);
                        return;
                    }
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
                    if (dc.ColumnName.IndexOf("id", StringComparison.InvariantCultureIgnoreCase) > -1 || dc.ColumnName.IndexOf("Marca_angajati", StringComparison.InvariantCultureIgnoreCase) > -1)
                    {
                        tx.Attributes.Add("disabled", "disabled");
                    }
                    row.Controls.Add(tx);
                }
                panel_Form.Controls.Add(row);
            }
            var btnRow = new HtmlGenericControl("div");
            var divClear = new HtmlGenericControl("div");
            divClear.Attributes.Add("class", "clear");
            var btnSave = new Button();
            btnSave.Text = "Actualizeaza";
            btnSave.Click += btnSave_Click;
            btnRow.Controls.Add(btnSave);
            btnRow.Controls.Add(divClear);
            btnRow.Attributes.Add("class", "edit-row");
            panel_Form.Controls.Add(btnRow);

            inapoiClick.Attributes.Add("onclick", "javascript:history.go(-1);return false");
            
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            string procName = "dbo.update" + char.ToUpper(type[0]) + type.Substring(1);
            var list = new List <KeyValuePair<string, string>>();
            var paramList = new BusinessLogic.BusinessLogic().ListParams(procName);
            var listValues = new List<string>();
            Control ctrl = FindControl("panel_Form");
            foreach (Control c in ctrl.Controls)
            {
                foreach (Control childc in c.Controls)
                {
                    if (childc is TextBox)
                    {
                        listValues.Add(((TextBox)childc).Text);
                    }
                    else if (childc is DropDownList)
                    {
                        listValues.Add(((DropDownList)childc).SelectedItem.Value);
                    }
                }
            }
            
           for(int i=1;i<paramList.Count;i++)
           { 
                list.Add(new KeyValuePair<string,string>(paramList[i],listValues[i-1])); 
           }

           Label lbl = new Label();
           lbl.Text = "";
           panel_Form.Controls.Add(lbl);

           try
           {
               SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql_Prod"].ConnectionString);
               SqlCommand cmd = new SqlCommand(procName, sqlconn);
               cmd.CommandType = CommandType.StoredProcedure;
               sqlconn.Open();
               foreach (var parameters in list)
               {
                   cmd.Parameters.AddWithValue(parameters.Key, parameters.Value);
               }
               lbl.Text = Convert.ToBoolean(cmd.ExecuteNonQuery()) ? "Modificarile au fost salvate cu succes!" : "Nu s-au modificat campurile!";
               sqlconn.Close();
           }
           catch (Exception ex)
           {
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