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
    }
}
