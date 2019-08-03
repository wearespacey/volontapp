using System.Threading.Tasks;

namespace VolontApp.DAL.Repositories
{
    public interface IRepository<T>
    {
        string Create(T entity, string id);
        Task<string> CreateAsync(T entity, string id);

        T Read(string id);
        Task<T> ReadAsync(string id);

        void Update(string id, T entity);
        Task UpdateAsync(string id, T entity);

        void Delete(string id);
        Task DeleteAsync(string id);
    }
}
