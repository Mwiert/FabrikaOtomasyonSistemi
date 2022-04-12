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
                var query =new StringBuilder();

                query.Append("Select * from Users where UserMail = @UserMail AND UserPassword = @UserPassword");
                string cmdText = query.ToString();

                using (var dbConnection = new SqlConnection(connectionString))
                {

                    if(dbConnection.State !=ConnectionState.Open)
                    {
                        dbConnection.Open();
                    }
                    using (var command = new SqlCommand(cmdText))
                    {
                        command.Connection = dbConnection;

                        DbHelper.addParameter(command, "@UserMail", Username, DbType.String, ParameterDirection.Input);
                        DbHelper.addParameter(command, "@UserPassword",Password,DbType.String,ParameterDirection.Input);

                        using (var reader = command.ExecuteReader()) 
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    user.Email = reader.GetString(4);
                                    user.Password = reader.GetString(6);
                                    loginStatus = true;
                                }
                            }
                        }
                    }
                }
                return (loginStatus, user);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    
    
   
        public User InsertUser(User user)
        {
            try
            {
                var query = new StringBuilder();

                query.Append("INSERT INTO Users ([UserAd], [UserSoyad], [UserAdress],[UserEmail],[UserPhone],[UserKimlikno],[UserPassword]) + " +
                    "  Values (@UserAd), (@UserSoyad), (@UserAdress), (@UserEmail), (@UserPhone), (@UserKimlikno), (@UserPassword)");

                string commandText = query.ToString();

                using (var dbConnection = new SqlConnection(connectionString))
                {
                    if (dbConnection.State != ConnectionState.Open)
                    {
                        dbConnection.Open();
                    }

                    using (var command = new SqlCommand(commandText))
                    {
                        command.Connection = dbConnection;

                        DbHelper.addParameter(command, "@UserAd",user.Name,DbType.String,ParameterDirection.Input);
                        DbHelper.addParameter(command, "@UserSoyad", user.Lastname, DbType.String, ParameterDirection.Input);
                        DbHelper.addParameter(command, "@UserAdress", user.Adress, DbType.String, ParameterDirection.Input);
                        DbHelper.addParameter(command, "@UserEmail", user.Email, DbType.String, ParameterDirection.Input);
                        DbHelper.addParameter(command, "@UserPhone", user.PhoneNumber, DbType.String, ParameterDirection.Input);
                        DbHelper.addParameter(command, "@UserKimlikNo", user.IdNumber, DbType.String, ParameterDirection.Input);
                        DbHelper.addParameter(command, "@UserPassword", user.Password, DbType.String, ParameterDirection.Input);

                        command.ExecuteNonQuery();

                    }
                }
                return user;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
