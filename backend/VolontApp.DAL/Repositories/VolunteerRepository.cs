using VolontApp.Models;

namespace VolontApp.DAL.Repositories
{
    public class VolunteerRepository : RepositoryBase<Volunteer>
    {
        public VolunteerRepository(IDocumentStoreHolder documentHolder) : base(documentHolder)
        { }
    }
}
