using simpleproject.models;

namespace simpleproject.repository
{
    public class Repository<t>: repositoryid<t>, irepository<t> where t : class
    {
        public Repository(datacontext context):base(context) { }
    }
}
