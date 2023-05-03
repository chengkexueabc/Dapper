using Dapper;
using DapperSample.Dapper;
using DapperSample.Models;

namespace DapperSample.Repository
{
    public interface IProductRepository
    {
        Task<Product> GetAsync(int id);

        Task<IEnumerable<Product>> GetAllAsync();

        long Insert(Product model);

        Task<int> InsertAsync(Product model);

        bool Update(Product model);

        Task<bool> UpdateAsync(Product model);

        int Count(string where, object param = null);

        Task<int> CountAsync(string where, object param = null);

        bool Exists(string where, object param = null);

        Task<bool> ExistsAsync(string where, object param = null);

        Product FirstOrDefault(string where, object param = null);

        Task<Product> FirstOrDefaultAsync(string where, object param = null);

        T FirstOrDefault<T>(string sql, object param = null);

        Task<T> FirstOrDefaultAsync<T>(string sql, object param = null);

        IEnumerable<Product> Fetch(SqlBuilder where);

        Task<IEnumerable<Product>> FetchAsync(SqlBuilder where);

        IEnumerable<T> Fetch<T>(string sql, SqlBuilder where, bool orderBy = true);

        Task<IEnumerable<T>> FetchAsync<T>(string sql, SqlBuilder where, bool orderBy = true);

        Task<Page<Product>> PageAsync(long pageIndex, long pageSize, SqlBuilder builder);

        Task<Page<T>> PageAsync<T>(string sql, long pageIndex, long pageSize, SqlBuilder builder);

        Task<SqlMapper.GridReader> QueryMultipleAsync(string sql, object param = null);
    }
}
