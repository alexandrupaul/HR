using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ResurseUmane.Entities;
using ResurseUmane.Utils;
using System.Data.SqlClient;

namespace ResurseUmane.BusinessLogic
{
    public class BusinessLogic
    {
        public bool AdaugaBanca(Entities.Entities.Banca banca)
        {
            return new Procedure("dbo.insertBanci")
                .AddParameter("@Name", banca.NumeBanci)
                .AddParameter("@Cms", banca.Comision)
                .ExecuteNonQuery() > 0;
        }
    }
}