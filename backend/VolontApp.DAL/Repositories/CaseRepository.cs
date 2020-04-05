using System;
using System.Threading.Tasks;
using Raven.Client.Documents.Session;
using VolontApp.Models;

namespace VolontApp.DAL.Repositories
{
    public class CaseRepository : RepositoryBase<Case>
    {
        public CaseRepository(IDocumentStoreHolder documentStoreHolder) : base(documentStoreHolder)
        { }

        public override string Create(Case entity, string id)
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
                
                if (string.IsNullOrWhiteSpace(entity.CoordinatorId))
                {
                    var coordinator = session.Load<Coordinator>(entity.CoordinatorId);
                    if (coordinator == null)
                    {
                        entity.CoordinatorId = null;
                    }
                }

                if (string.IsNullOrWhiteSpace(entity.ChildId))
                {
                    var child = session.Load<Child>(entity.ChildId);
                    if (child == null)
                    {
                        entity.ChildId = null;
                    }
                }

                session.Store(entity, id);
                session.SaveChanges();
            }

            return id;
        }

        public override async Task<string> CreateAsync(Case entity, string id)
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

                if (string.IsNullOrWhiteSpace(entity.CoordinatorId))
                {
                    var coordinator = await session.LoadAsync<Coordinator>(entity.CoordinatorId);
                    if (coordinator == null)
                    {
                        entity.CoordinatorId = null;
                    }
                }

                if (string.IsNullOrWhiteSpace(entity.ChildId))
                {
                    var child = await session.LoadAsync<Child>(entity.ChildId);
                    if (child == null)
                    {
                        entity.ChildId = null;
                    }
                }

                await session.StoreAsync(entity, id);
                await session.SaveChangesAsync();
            }
            return id;
        }
    }
}
