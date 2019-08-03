using VolontApp.Models;

namespace VolontApp.DAL.Repositories
{
    public class MissingChildRepository : RepositoryBase<MissingChild>
    {
        public MissingChildRepository(DocumentStoreHolder documentStoreHolder): base(documentStoreHolder)
        { }
    }
}
