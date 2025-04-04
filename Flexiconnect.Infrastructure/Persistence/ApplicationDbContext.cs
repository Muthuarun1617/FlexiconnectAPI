using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flexiconnect.Infrastructure.Persistence
{
    public class ApplicationDbContext
    {
        private readonly string? _connectionString;
        public ApplicationDbContext(IConfiguration configuration) 
        {
            _connectionString = configuration.GetConnectionString("NextgenConn");
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        //public string constring = "Data Source=sqlmi-ci-duroconnect.public.fc24085f63b6.database.windows.net,3342;Initial Catalog=NGDT_dev;User ID=gsr.dbuser;Password=NGDT@123";
    }
}
