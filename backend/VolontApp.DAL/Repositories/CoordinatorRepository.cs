using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        
        public override Coordinator Read(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException(nameof(id));

            using (IDocumentSession session = this.Store.OpenSession())
            {
                Coordinator coordinator = session
                    .Include<Coordinator>(c => c.VolunteerIds)
                    .Load<Coordinator>(id);

                if (coordinator.VolunteerIds != null)
                {
                    coordinator.Volunteers = new List<Volunteer>();
                    foreach (string volunteerId in coordinator.VolunteerIds)
                    {
                        coordinator.Volunteers.Add(session.Load<Volunteer>(volunteerId));
                    }
                    coordinator.VolunteerIds = null;
                }

                return coordinator;
            }
        }

        public override async Task<Coordinator> ReadAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException(nameof(id));

            using (IAsyncDocumentSession session = this.Store.OpenAsyncSession())
            {
                Coordinator coordinator = await session
                    .Include<Coordinator>(c => c.VolunteerIds)
                    .LoadAsync<Coordinator>(id);

                if (coordinator.VolunteerIds != null)
                {
                    coordinator.Volunteers = new List<Volunteer>();
                    foreach (string volunteerId in coordinator.VolunteerIds)
                    {
                        coordinator.Volunteers.Add(await session.LoadAsync<Volunteer>(volunteerId));
                    }
                    coordinator.VolunteerIds = null;
                }

                return coordinator;
            }
        }
    }
}
