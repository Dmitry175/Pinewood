using Dapper;
using Microsoft.Data.Sqlite;

namespace Pinewood.Interfaces
{
    public interface IADOProvider
    {
        public SqliteConnection SQLADOProvider { get; }
        public Task<IEnumerable<T>> QueryAsync<T>(string sql);
        public Task<IEnumerable<T>> QueryAsync<T>(string sql, DynamicParameters d);
    }
}
