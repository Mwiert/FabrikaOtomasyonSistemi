using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOSystem.Models;
using FOSystem.DataAccess.Concretes;
using FOSystem.Models.Concretes;

namespace FOSystem.Business.Concretes
{
    public class AdminBusiness
    {
        public bool adminLogin(string Username,string Password)
        {
            try
            {
                bool loginStatus = false;
                using (var repository = new AdminRepository())
                {
                    loginStatus = repository.adminLogin(Username, Password);
                }
                return loginStatus;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public Orders InsertOrder(Orders order)
        {
            try
            {
                Orders orders = new Orders();
                using (var repository = new AdminRepository())
                {
                    orders = repository.SiparisOlustur(order);
                }
                return orders;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public IList<Product> getAllProducts()
        {
            try
            {
                IList<Product> products = new List<Product>();

                using (var repository = new AdminRepository())
                {
                    products = repository.selectAll();
                }
                return products;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public Product InsertProduct(Product product)
        {
            try
            {
                Product product_ = new Product();

                using (var repository = new AdminRepository())
                {
                    product_ = repository.insert(product);
                }
                return product_;
            }
            catch (Exception ex)
            {

                throw ex;
            }



        }
    }
}
