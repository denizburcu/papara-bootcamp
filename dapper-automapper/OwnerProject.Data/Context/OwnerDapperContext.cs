using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace OwnerProject.Data.Context
{
    public class OwnerDapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string? _connectionString;

        //We inject the IConfiguration interface to enable access to the connection string from our appsettings.json file.
        public OwnerDapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}