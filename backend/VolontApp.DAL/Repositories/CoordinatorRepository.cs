using System;
using System.Linq;
using System.Threading.Tasks;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using VolontApp.Models;

namespace VolontApp.DAL.Repositories
{
    public class CoordinatorRepository : RepositoryBase<Coordinator>
    {
        public CoordinatorRepository(IDocumentStoreHolder documentStoreHolder) : base(documentStoreHolder)
        { }

        public override string Create(Coordinator entity, string id)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException(nameof(id));

            using (IDocumentSession session = this.Store.OpenSession())
            {
                if (entity.VolunteerIds != null)
                {
                    foreach (string volunteerId in entity.VolunteerIds)
                    {
                        var volunteer = session.Load<Volunteer>(volunteerId);
                        if (volunteer == null)
                        {
                            entity.VolunteerIds.RemoveAll(vId => vId.Equals(volunteerId));
                        }
                    }
                }

                session.Store(entity, id);
                session.SaveChanges();
            }

            return id;
        }

        public override async Task<string> CreateAsync(Coordinator entity, string id)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException(nameof(id));

            using (IAsyncDocumentSession session = this.Store.OpenAsyncSession())
            {
                if (entity.VolunteerIds != null)
                {
                    foreach (string volunteerId in entity.VolunteerIds)
                    {
                        var volunteer = await session.LoadAsync<Volunteer>(volunteerId);
                        if (volunteer == null)
                        {
                            entity.VolunteerIds.RemoveAll(vId => vId.Equals(volunteerId));
                        }
                    }
                }

                await session.StoreAsync(entity, id);
                await session.SaveChangesAsync();
            }
            return id;
        }

        public Coordinator ReadByInstallId(string installId)
        {
            if (string.IsNullOrWhiteSpace(installId)) throw new ArgumentNullException(nameof(installId));

            using (IDocumentSession session = this.Store.OpenSession())
            {
                return session.Query<Coordinator>().FirstOrDefault(v => v.InstallId == installId);
            }
        }

        public Task<Coordinator> ReadByInstallIdAsync(string installId)
        {
            if (string.IsNullOrWhiteSpace(installId)) throw new ArgumentNullException(nameof(installId));

            using (IDocumentSession session = this.Store.OpenSession())
            {
                return session.Query<Coordinator>().FirstOrDefaultAsync(v => v.InstallId == installId);
            }
        }
    }
}
