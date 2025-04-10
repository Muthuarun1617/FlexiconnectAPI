using Dapper;
using Flexiconnect.Infrastructure.Persistence.Repositories.Interfaces;

namespace Flexiconnect.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        public GenericRepository(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAsync(string objectname)
        {
            using (var conn = _context.CreateConnection())
            {
                return await conn.QueryAsync<T>(objectname, null, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public async Task AddAsync(string objectname, DynamicParameters parameters)
        {
            using (var conn = _context.CreateConnection())
            {
                await conn.QueryAsync<T>(objectname, parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public async Task UpdateAsync(string objectname, DynamicParameters parameters)
        {
            using (var conn = _context.CreateConnection())
            {
                await conn.QueryAsync<T>(objectname, parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
