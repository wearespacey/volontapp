using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;

namespace VolontApp.DAL.Repositories
{
    public class RepositoryBase<T> : IRepository<T>
    {
        public IDocumentStore Store { get; set; }

        public RepositoryBase(IDocumentStoreHolder documentStoreHolder)
        {
            this.Store = documentStoreHolder.Store;
        }

        public string Create(T entity, string id)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException(nameof(id));

            using (IDocumentSession session = this.Store.OpenSession())
            {
                session.Store(entity, id);
                session.SaveChanges();
            }

            return id;
        }

        public async Task<string> CreateAsync(T entity, string id)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException(nameof(id));

            using (IAsyncDocumentSession session = this.Store.OpenAsyncSession())
            {
                await session.StoreAsync(entity, id);
                await session.SaveChangesAsync();
            }
            return id;
        }

        public IEnumerable<T> ReadAll()
        {
            using(IDocumentSession session = this.Store.OpenSession())
            {
                return session.Query<T>().ToList();
            }
        }

        public async Task<IEnumerable<T>> ReadAllAsync()
        {
            using (IAsyncDocumentSession session = this.Store.OpenAsyncSession())
            {
                return await session.Query<T>().ToListAsync();
            }
        }

        public T Read(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException(nameof(id));

            using (IDocumentSession session = this.Store.OpenSession())
            {
                return session.Load<T>(id);
            }
        }

        public Task<T> ReadAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException(nameof(id));

            using (IAsyncDocumentSession session = this.Store.OpenAsyncSession())
            {
                return session.LoadAsync<T>(id);
            }
        }

        public void Update(string id, T entity)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException(nameof(id));
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            using (IDocumentSession session = this.Store.OpenSession())
            {
                session.Store(entity, id);
                session.SaveChanges();
            }
        }

        public async Task UpdateAsync(string id, T entity)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException(nameof(id));
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            using (IAsyncDocumentSession session = this.Store.OpenAsyncSession())
            {
                await session.StoreAsync(entity, id);
                await session.SaveChangesAsync();
            }
        }

        public void Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException(nameof(id));

            using (IDocumentSession session = this.Store.OpenSession())
            {
                session.Delete(id);
                session.SaveChanges();
            }
        }

        public async Task DeleteAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException(nameof(id));

            using (IAsyncDocumentSession session = this.Store.OpenAsyncSession())
            {
                session.Delete(id);
                await session.SaveChangesAsync();
            }
        }
    }
}
