using VolontApp.Models;

namespace VolontApp.DAL.Repositories
{
    public class DisplayRepository : RepositoryBase<Display>
    {
        public DisplayRepository(IDocumentStoreHolder documentStoreHolder) : base(documentStoreHolder)
        { }
    }
}
