using VolontApp.Models;

namespace VolontApp.DAL.Repositories
{
    public class CoordinatorRepository : RepositoryBase<Coordinator>
    {
        public CoordinatorRepository(IDocumentStoreHolder documentStoreHolder) : base(documentStoreHolder)
        { }
    }
}
