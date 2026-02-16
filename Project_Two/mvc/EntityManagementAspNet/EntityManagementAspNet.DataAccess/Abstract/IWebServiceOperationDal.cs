using EntityManagementAspNet.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EntityManagementAspNet.DataAccess.Abstract
{
    public interface IWebServiceOperationDal: IEntityRepository<WebServiceOperation>
    {
        List<WebServiceOperation> GetAll(Expression<Func<WebServiceOperation, bool>> filter = null);
        void Delete(WebServiceOperation webServiceOperation);
    }
}
