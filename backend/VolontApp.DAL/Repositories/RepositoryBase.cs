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

        public virtual string Create(T entity, string id)
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

        public virtual async Task<string> CreateAsync(T entity, string id)
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

        public virtual IEnumerable<T> ReadAll()
        {
            using(IDocumentSession session = this.Store.OpenSession())
            {
                return session.Query<T>().ToList();
            }
        }

        public virtual async Task<IEnumerable<T>> ReadAllAsync()
        {
            using (IAsyncDocumentSession session = this.Store.OpenAsyncSession())
            {
                return await session.Query<T>().ToListAsync();
            }
        }

        public virtual T Read(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException(nameof(id));

            using (IDocumentSession session = this.Store.OpenSession())
            {
                return session.Load<T>(id);
            }
        }

        public virtual Task<T> ReadAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException(nameof(id));

            using (IAsyncDocumentSession session = this.Store.OpenAsyncSession())
            {
                return session.LoadAsync<T>(id);
            }
        }

        public virtual void Update(T entity, string id)
        {
            this.Create(entity, id);
        }

        public async Task UpdateAsync(T entity, string id)
        {
            await this.CreateAsync(entity, id);
        }

        public virtual void Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException(nameof(id));

            using (IDocumentSession session = this.Store.OpenSession())
            {
                session.Delete(id);
                session.SaveChanges();
            }
        }

        public virtual async Task DeleteAsync(string id)
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
