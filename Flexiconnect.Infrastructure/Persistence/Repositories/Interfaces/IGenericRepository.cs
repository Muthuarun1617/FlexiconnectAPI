using Dapper;

namespace Flexiconnect.Infrastructure.Persistence.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAsync(string objectname, DynamicParameters parameters);

        Task AddAsync(string objectname, DynamicParameters parameters);

        Task UpdateAsync(string objectname, DynamicParameters parameters);
        //Task<(IEnumerable<T1> result1, T2 result2)> GetMultipleAsync<T1, T2>(string procName, DynamicParameters parameters);
    }
}
