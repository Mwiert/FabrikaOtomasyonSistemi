using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOSystem.Models;
using FOSystem.Models.Concretes;
using FOSystem.DataAccess.Abstractions;
using FOSystem.DataAccess.Concretes;
using FOSystem.Commons.Concretes.Helpers;
using System.Data.SqlClient;

namespace FOSystem.Business.Concretes
{
    public class UserBusiness
    {
        public (bool,User) UserLogin(string Username, string Password)
        {
            try
            {
                bool LoginStatus = false;
                User user = new User();

                using (var repository = new UserRepository())
                {
                    LoginStatus = repository.userLogin(Username, Password).Item1;
                    user = repository.userLogin(Username,Password).Item2;
                }
                return (LoginStatus, user);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public User InsertUser (User user)
        {
            try
            {
                User user2 = new User();
                using (var repository = new UserRepository())
                {
                    user2 = repository.InsertUser(user);
                }
                return user2;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
