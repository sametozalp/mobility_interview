using EntityManagementAspNet.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EntityManagementAspNet.DataAccess.Abstract
{
    public interface IPersonDal: IEntityRepository<Person>
    {        
        List<Person> GetAll(Expression<Func<Person, bool>> filter = null);
        void Delete(Person person);
    }
}
