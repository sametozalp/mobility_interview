using EntityManagementAspNet.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityManagementAspNet.DataAccess.Abstract
{
    public interface IEntityRepository<T>
    {
        void Add(T entity);

    }
}
