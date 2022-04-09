using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOSystem.DataAccess.Abstractions;
using FOSystem.Models;
using FOSystem.Models.Concretes;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using FOSystem.Commons.Concretes.Helpers;


namespace FOSystem.DataAccess.Concretes
{
    public class UserRepository : IDisposable
    {
        public string connectionString { get; set; }
        public bool loginStatus { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
        public UserRepository()
        {
            connectionString = DbHelper.getConnectionString();
            loginStatus = false;  
        }

        public (bool,User) userLogin(string Username,string Password)
        {
            try
            {
                User user = new User();
                var query = new StringBuilder();
                query.Append();






                return (loginStatus, user);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
