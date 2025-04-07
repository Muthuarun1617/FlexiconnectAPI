using Flexiconnect.Shared.Constants;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Flexiconnect.Infrastructure.Persistence
{
    public class ApplicationDbContext
    {
        private readonly string? _connectionString;
        public ApplicationDbContext(IConfiguration configuration) 
        {
            _connectionString = configuration.GetConnectionString(DBConstants.DBConnString);
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
