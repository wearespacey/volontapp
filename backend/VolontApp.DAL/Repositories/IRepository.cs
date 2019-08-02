using System.Threading.Tasks;

namespace VolontApp.DAL.Repositories
{
    public interface IRepository<T>
    {
        string Create(T entity, string entityId);
        Task<string> CreateAsync(T entity, string entityId);

        T Read(string id);
        Task<T> ReadAsync(string id);

        void Update(T entity);
        Task UpdateAsync(T entity);

        void Delete(string id);
        Task DeleteAsync(string id);
    }
}
