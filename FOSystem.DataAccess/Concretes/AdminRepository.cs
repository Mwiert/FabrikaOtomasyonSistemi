using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using FOSystem.DataAccess.Abstractions;
using FOSystem.Models.Concretes;

namespace FOSystem.DataAccess.Concretes
{
    public class AdminRepository : IRepository<Product>, IDisposable
    {
        public void delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }

        public Product insert(Product entity)
        {
            throw new NotImplementedException();
        }

        public IList<Product> selectAll()
        {
            throw new NotImplementedException();
        }

        public Product selectyByID(int id)
        {
            throw new NotImplementedException();
        }

        public Product SiparisOlustur(int id)
        {
            throw new NotImplementedException();
        }

        public Product update(int id, Product updated)
        {
            throw new NotImplementedException();
        }
    }
}
