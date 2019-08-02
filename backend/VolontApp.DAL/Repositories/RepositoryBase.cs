﻿using System;
using System.Threading.Tasks;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;

namespace VolontApp.DAL.Repositories
{
    public class RepositoryBase<T> : IRepository<T>
    {
        private readonly IDocumentStore _store;

        public RepositoryBase(IDocumentStoreHolder documentHolder)
        {
            this._store = documentHolder.Store;
        }

        public string Create(T entity, string entityId)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            using (IDocumentSession session = this._store.OpenSession())
            {
                session.Store(entity, entityId);
                session.SaveChanges();
            }

            return entityId;
        }

        public async Task<string> CreateAsync(T entity, string entityId)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            using (IAsyncDocumentSession session = this._store.OpenAsyncSession())
            {
                await session.StoreAsync(entity, entityId);
                await session.SaveChangesAsync();
            }

            return entityId;
        }

        public T Read(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException();

            using (IDocumentSession session = this._store.OpenSession())
            {
                return session.Load<T>(id);
            }
        }

        public Task<T> ReadAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException();

            using (IAsyncDocumentSession session = this._store.OpenAsyncSession())
            {
                return session.LoadAsync<T>(id);
            }
        }

        public void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException();

            using (IDocumentSession session = this._store.OpenSession())
            {
                session.Store(entity);
                session.SaveChanges();
            }
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException();

            using (IAsyncDocumentSession session = this._store.OpenAsyncSession())
            {
                await session.StoreAsync(entity);
                await session.SaveChangesAsync();
            }
        }

        public void Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException();

            using (IDocumentSession session = this._store.OpenSession())
            {
                session.Delete(id);
                session.SaveChanges();
            }
        }

        public async Task DeleteAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException();

            using (IAsyncDocumentSession session = this._store.OpenAsyncSession())
            {
                session.Delete(id);
                await session.SaveChangesAsync();
            }
        }
    }