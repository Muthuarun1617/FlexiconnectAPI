using Flexiconnect.Infrastructure.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Net;
using Microsoft.IdentityModel.Protocols;
using System.Data;

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
                return await conn.QueryAsync<T>("dbo.sp_fetch_actionmenu", null, commandType: System.Data.CommandType.StoredProcedure);
            }
            
        }
    }
}
