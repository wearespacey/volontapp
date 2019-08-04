using System;
using System.Collections.Generic;
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

        public override Case Read(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException(nameof(id));

            using (IDocumentSession session = this.Store.OpenSession())
            {
                Case Case = session
                    .Include<Case>(c => c.VolunteerIds)
                    .Load<Case>(id);

                if (Case.VolunteerIds != null)
                {
                    Case.Volunteers = new List<Volunteer>();
                    foreach (string volunteerId in Case.VolunteerIds)
                    {
                        Case.Volunteers.Add(session.Load<Volunteer>(volunteerId));
                    }
                    Case.VolunteerIds = null;
                }

                if (!string.IsNullOrWhiteSpace(Case.CoordinatorId))
                {
                    var coordinator = session.Load<Coordinator>(Case.CoordinatorId);
                    if (coordinator != null)
                    {
                        Case.Coordinator = coordinator;
                        Case.CoordinatorId = null;
                    }
                }

                if (string.IsNullOrWhiteSpace(Case.ChildId))
                {
                    var child = session.Load<Child>(Case.ChildId);
                    if (child != null)
                    {
                        Case.Child = child;
                        Case.ChildId = null;
                    }
                }

                return Case;
            }
        }

        public override async Task<Case> ReadAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException(nameof(id));

            using (IAsyncDocumentSession session = this.Store.OpenAsyncSession())
            {
                Case Case = await session
                    .Include<Case>(c => c.VolunteerIds)
                    .LoadAsync<Case>(id);

                if (Case.VolunteerIds != null)
                {
                    Case.Volunteers = new List<Volunteer>();
                    foreach (string volunteerId in Case.VolunteerIds)
                    {
                        Case.Volunteers.Add(await session.LoadAsync<Volunteer>(volunteerId));
                    }
                    Case.VolunteerIds = null;
                }

                if (!string.IsNullOrWhiteSpace(Case.CoordinatorId))
                {
                    var coordinator = await session.LoadAsync<Coordinator>(Case.CoordinatorId);
                    if (coordinator != null)
                    {
                        Case.Coordinator = coordinator;
                        Case.CoordinatorId = null;
                    }
                }

                if (string.IsNullOrWhiteSpace(Case.ChildId))
                {
                    var child = await session.LoadAsync<Child>(Case.ChildId);
                    if (child != null)
                    {
                        Case.Child = child;
                        Case.ChildId = null;
                    }
                }

                return Case;
            }
        }
    }
}
