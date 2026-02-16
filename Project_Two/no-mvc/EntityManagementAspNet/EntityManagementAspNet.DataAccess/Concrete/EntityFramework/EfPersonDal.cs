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
    public class EfPersonDal : IPersonDal
    {
        public void Add(Person person)
        {
            using (MyContext myContext = new MyContext())
            {
                var added = myContext.Entry(person);
                added.State = EntityState.Added;
                myContext.SaveChanges();
            }
        }

        public void Delete(Person person)
        {
            using (MyContext myContext = new MyContext())
            {
                var deleted = myContext.Entry(person);
                deleted.State = EntityState.Deleted;
                myContext.SaveChanges();
            }
        }

        public List<Person> GetAll(Expression<Func<Person, bool>> filter = null)
        {
            using (MyContext myContext = new MyContext())
            {
                return filter == null 
                    ? myContext.Set<Person>().ToList()
                    : myContext.Set<Person>().Where(filter).ToList();
            }
        }
    }
}
