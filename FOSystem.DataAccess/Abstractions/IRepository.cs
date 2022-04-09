using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOSystem.DataAccess.Abstractions
{
    public interface IRepository<Type> where Type : class
    {
        Type insert(Type entity);
        IList<Type> selectAll();
        Type selectyByID(int id);
        Type update(int id, Type updated);
        void delete(int id);
        Type SiparisOlustur(int id);
    }
}
