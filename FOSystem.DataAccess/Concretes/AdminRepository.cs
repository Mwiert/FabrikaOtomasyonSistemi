using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOSystem.DataAccess.Abstractions;
using FOSystem.Models.Concretes;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Data;
using FOSystem.Commons.Concretes.Helpers;

namespace FOSystem.DataAccess.Concretes
{
    public class AdminRepository : IRepository<Product>, IDisposable
    {
        public string connectionString { get; set; }
        public bool loginStatus { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
        public bool adminLogin(string username, string password)
        {
            try
            {
                var query = new StringBuilder();
                query.Append("Select * FROM Admin Where Username =@Username AND Password = @Password");

                string commandText = query.ToString();

                using (var dbConnection = new SqlConnection(connectionString))
                {
                    if(dbConnection.State !=ConnectionState.Open)
                    {
                        dbConnection.Open();
                    }
                    using (var command= new SqlCommand(commandText))
                    {
                       command.Connection = dbConnection;
                        DbHelper.addParameter(command, "@Username", username, DbType.String, ParameterDirection.Input);
                        DbHelper.addParameter(command, "@Password", password, DbType.String, ParameterDirection.Input);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while(reader.Read())
                                {
                                    loginStatus = true;
                                }
                            }
                        }
                    }
                }
                return loginStatus;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Product insert(Product entity)
        {
            try
            {
                var query = new StringBuilder();

                query.Append("INSERT INTO Product ([ProductEn], [ProductBoy], [ProductYukselik], [ProductAdedi], [ProductAdi]) + " +
                    " Values (@ProductEn, @ProductBoy, @ProductYukselik, @ProductAdedi, @ProductAdi)");

                string commandText = query.ToString();

                using (var dbConnection = new SqlConnection(connectionString))
                {
                    using (var cmd = new SqlCommand(commandText))
                    {
                        cmd.Connection = dbConnection;
                        DbHelper.addParameter(cmd, "@ProductEn", entity.ProductEn, DbType.Double, ParameterDirection.Input);
                        DbHelper.addParameter(cmd, "@ProductBoy", entity.ProductBoy, DbType.Double, ParameterDirection.Input);
                        DbHelper.addParameter(cmd, "@ProductYukseklik", entity.ProductYukselik, DbType.Double, ParameterDirection.Input);
                        DbHelper.addParameter(cmd, "@ProductAdedi", entity.ProductAdedi, DbType.Int32, ParameterDirection.Input);
                        DbHelper.addParameter(cmd, "@ProductAdi", entity.ProductAdi, DbType.String, ParameterDirection.Input);
                        if(dbConnection.State != ConnectionState.Open)
                        {
                            dbConnection.Open();
                        }
                        cmd.ExecuteNonQuery();
                    }
                }
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IList<Product> selectAll()
        {
            try
            {
                List<Product> productList = new List<Product>();
                var query = new StringBuilder();

                query.Append("Select ProductId, ProductAdi from Product");
                string cmdText = query.ToString();

                using (var dbCon = new SqlConnection(connectionString))
                {
                    using(var cmd = new SqlCommand(cmdText))
                    {
                        cmd.Connection = dbCon;
                        if(dbCon.State != ConnectionState.Open)
                        {
                            dbCon.Open();
                        }
                        using(var reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    Product product = new Product();
                                    product.ProductAdi = reader.GetString(6);
                                    productList.Add(product);
                                }
                            }
                        }
                    }
                }
                return productList;
            }
            catch (Exception ex)
            {

                throw ex; 
            }
        }

        public Product SiparisOlustur(int id)
        {
            throw new NotImplementedException();
        }
    }
}
