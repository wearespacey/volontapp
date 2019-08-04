using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Raven.Client.Documents;
using Raven.Client.Documents.Linq;
using Raven.Client.Documents.Session;
using VolontApp.Models;

namespace VolontApp.DAL.Repositories
{
    public class VolunteerRepository : RepositoryBase<Volunteer>
    {
        public VolunteerRepository(IDocumentStoreHolder documentStoreHolder) : base(documentStoreHolder)
        { }

        public IEnumerable<Volunteer> ReadAllByCoordinator(string coordinatorId)
        {
            var volunteers = new List<Volunteer>();
            using (IDocumentSession session = this.Store.OpenSession())
            {
                var coordinator = session.Include<Volunteer>(v => v.Id).Load<Coordinator>(coordinatorId);

                if (coordinator != null)
                {
                    foreach (string vId in coordinator.VolunteerIds)
                    {
                        volunteers.Add(session.Load<Volunteer>(vId));
                    }
                }

                return volunteers;
            }
        }

        public async Task<IEnumerable<Volunteer>> ReadAllByCoordinatorAsync(string id)
        {
            var volunteers = new List<Volunteer>();
            using (IAsyncDocumentSession session = this.Store.OpenAsyncSession())
            {
                var coordinator = await session.Include("Volunteer").LoadAsync<Coordinator>(id);

                if (coordinator != null)
                {
                    foreach (string vId in coordinator.VolunteerIds)
                    {
                        volunteers.Add(await session.LoadAsync<Volunteer>(vId));
                    }
                }

                return volunteers;
            }
        }

        public Volunteer ReadByInstallId(string installId)
        {
            if (string.IsNullOrWhiteSpace(installId)) throw new ArgumentNullException(nameof(installId));

            using (IDocumentSession session = this.Store.OpenSession())
            {
                return session.Query<Volunteer>().FirstOrDefault(v => v.InstallId == installId);
            }
        }

        public Task<Volunteer> ReadByInstallIdAsync(string installId)
        {
            if (string.IsNullOrWhiteSpace(installId)) throw new ArgumentNullException(nameof(installId));

            using (IDocumentSession session = this.Store.OpenSession())
            {
                return session.Query<Volunteer>().FirstOrDefaultAsync(v => v.InstallId == installId);
            }
        }
    }
}
