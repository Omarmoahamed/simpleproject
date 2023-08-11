using Microsoft.EntityFrameworkCore;
using simpleproject.models;

namespace simpleproject.repository
{
    public class repositoryid<t> where t : class
    {
        
        public repositoryid(datacontext context) 
        {
            this.context = context;
           dbset = context.Set<t>();
        }
        protected DbSet<t> dbset { get; }
        protected datacontext context { get; set; }

        
        public IQueryable<t> Query()
        {
            return dbset;
        }
    }
}
