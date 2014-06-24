using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;


namespace ResurseUmane.Utils
{

    public class Procedure
    {
        private SqlConnection sql;
        private SqlCommand sqlCmd;

        public class Parameter
        {
            public string Key { get; set; }
            public object Value { get; set; }
        }

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

        public Procedure AddParameter(List<Procedure.Parameter> parameters)
        {
            foreach (var param in parameters)
            {
                this.AddParameter(param.Key, param.Value);
            }

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

        public DataTable ExecuteDataTable()
        {

            DataTable dt = new DataTable();

            try
            {
                this.sql.Open();
                if (this.sql.State == System.Data.ConnectionState.Open)
                {
                    SqlDataAdapter da = new SqlDataAdapter(this.sqlCmd);
                    da.Fill(dt);
                    return dt;

                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                this.sql.Close();
            }

            return null;

        }

        public List<DataTable> ExecuteDataTables()
        {
            var dts = new List<DataTable>();

            try
            {
                this.sql.Open();
                if (this.sql.State == ConnectionState.Open)
                {
                    SqlDataAdapter da = new SqlDataAdapter(this.sqlCmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    foreach (var table in ds.Tables)
                    {
                        dts.Add((DataTable)table);
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            return dts;
        }

    }
}