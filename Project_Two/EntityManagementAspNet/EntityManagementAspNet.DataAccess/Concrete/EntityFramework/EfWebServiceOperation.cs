using EntityManagementAspNet.DataAccess.Abstract;
using EntityManagementAspNet.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EntityManagementAspNet.DataAccess.Concrete.EntityFramework
{
    public class EfWebServiceOperation: IWebServiceOperationDal
    {
        public void Add(WebServiceOperation web)
        {
            using (MyContext myContext = new MyContext())
            {
                var added = myContext.Entry(web);
                added.State = EntityState.Added;
                myContext.SaveChanges();
            }
        }

        public void Delete(WebServiceOperation web)
        {
            using (MyContext myContext = new MyContext())
            {
                var deleted = myContext.Entry(web);
                deleted.State = EntityState.Deleted;
                myContext.SaveChanges();
            }
        }

        public List<WebServiceOperation> GetAll(Expression<Func<WebServiceOperation, bool>> filter = null)
        {
            using (MyContext myContext = new MyContext())
            {
                return filter == null
                    ? myContext.Set<WebServiceOperation>().ToList()
                    : myContext.Set<WebServiceOperation>().Where(filter).ToList();
            }
        }
    }
}
