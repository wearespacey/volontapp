using VolontApp.Models;

namespace VolontApp.DAL.Repositories
{
    public class ChildRepository : RepositoryBase<Child>
    {
        public ChildRepository(DocumentStoreHolder documentStoreHolder): base(documentStoreHolder)
        { }
    }
}
