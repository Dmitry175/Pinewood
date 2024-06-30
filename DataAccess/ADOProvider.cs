using Dapper;
using Microsoft.Data.Sqlite;
using Pinewood.Interfaces;

namespace Pinewood.DataAccess
{
    public class ADOProvider : IADOProvider
    {
        private readonly IConfiguration _configuration;
        public SqliteConnection SQLADOProvider { get { return new SqliteConnection(_configuration.GetConnectionString("DefaultConnection")); } }

        public ADOProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public async Task<IEnumerable<T>> QueryAsync<T>(string sql)
        {
            var con = new SqliteConnection(_configuration.GetConnectionString("DefaultConnection"));
            using (SQLADOProvider)
            {
                return await SQLADOProvider.QueryAsync<T>(sql);
            }
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, DynamicParameters d)
        {
            using (SQLADOProvider)
            {
                return await SQLADOProvider.QueryAsync<T>(sql, d);
            }
        }
    }
}
