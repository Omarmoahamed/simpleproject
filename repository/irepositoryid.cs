namespace simpleproject.repository
{
    public interface irepositoryid<t>
    {
        public IQueryable<t> Query();
    }
}
