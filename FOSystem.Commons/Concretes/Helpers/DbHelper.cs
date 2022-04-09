using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data;

namespace FOSystem.Commons.Concretes.Helpers
{
    public static class DbHelper
    {
        public static string getConnectionString()
        {
            string connectionString = "Data Source=MWIERT;Initial Catalog=FOSystem;Integrated Security=True";
            return connectionString;
        }

        public static void addParameter(DbCommand command,string paramName,object paramValue,DbType paramType, ParameterDirection direction)
        {
            DbParameter dbParameter = command.CreateParameter();
            dbParameter.ParameterName = paramName;
            dbParameter.DbType = paramType;
            dbParameter.Direction = direction;
            dbParameter.Value = paramValue;
            command.Parameters.Add(dbParameter);
        }
    }
}
