namespace Flexiconnect.Infrastructure.Persistence.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAsync(string objectname);   
    }
}
