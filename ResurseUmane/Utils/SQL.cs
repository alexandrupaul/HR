using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace ResurseUmane.Utils
{

    public class Procedure
    {
        private SqlConnection sql;
        private SqlCommand sqlCmd;

        public Procedure(string procedureName)
        {
            this.sql = new SqlConnection(ConfigurationManager.ConnectionStrings["sql_Prod"].ConnectionString);
            this.sqlCmd = new SqlCommand(procedureName, this.sql);
            this.sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
        }

        public Procedure AddParameter(string paramName, object paramValue)
        {
            this.sqlCmd.Parameters.AddWithValue(paramName, paramValue);

            return this;
        }

        public int ExecuteNonQuery()
        {
            try
            {
                this.sql.Open();
                if (this.sql.State == System.Data.ConnectionState.Open)
                {
                    return this.sqlCmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                this.sql.Close();
            }

            return 0;
        }
    }
}