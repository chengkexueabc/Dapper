using Dapper;
using DapperSample.Dapper;
using DapperSample.Models;

namespace DapperSample.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DapperDBContext _context;
        public ProductRepository(DapperDBContext context)
        {
            _context = context;
        }

        public async Task<Product> GetAsync(int id)
        {
            return await _context.GetAsync<Product>(id);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.GetAllAsync<Product>();
        }

        public long Insert(Product model)
        {
            return _context.Insert<Product>(model);
        }

        public async Task<int> InsertAsync(Product model)
        {
            return await _context.InsertAsync<Product>(model);
        }

        public bool Update(Product model)
        {
            return _context.Update<Product>(model);
        }

        public async Task<bool> UpdateAsync(Product model)
        {
            return await _context.UpdateAsync<Product>(model);
        }

        public int Count(string where, object param = null)
        {
            string strSql = $"SELECT COUNT(1) FROM Product {where}";
            return _context.ExecuteScalar(strSql, param);
        }

        public async Task<int> CountAsync(string where, object param = null)
        {
            string strSql = $"SELECT COUNT(1) FROM Product {where}";
            return await _context.ExecuteScalarAsync(strSql, param);
        }

        public bool Exists(string where, object param = null)
        {
            string strSql = $"SELECT TOP 1 1 FROM Product {where}";
            var count = _context.ExecuteScalar(strSql, param);
            return count > 0;
        }

        public async Task<bool> ExistsAsync(string where, object param = null)
        {
            string strSql = $"SELECT TOP 1 1 FROM Product {where}";
            var count = await _context.ExecuteScalarAsync(strSql, param);
            return count > 0;
        }

        public Product FirstOrDefault(string where, object param = null)
        {
            string strSql = $"SELECT TOP 1 * FROM Product {where}";
            return _context.QueryFirstOrDefault<Product>(strSql, param);
        }

        public async Task<Product> FirstOrDefaultAsync(string where, object param = null)
        {
            string strSql = $"SELECT TOP 1 * FROM Product {where}";
            return await _context.QueryFirstOrDefaultAsync<Product>(strSql, param);
        }

        public T FirstOrDefault<T>(string sql, object param = null)
        {
            return _context.QueryFirstOrDefault<T>(sql, param);
        }

        public async Task<T> FirstOrDefaultAsync<T>(string sql, object param = null)
        {
            return await _context.QueryFirstOrDefaultAsync<T>(sql, param);
        }

        public IEnumerable<Product> Fetch(SqlBuilder where)
        {
            var strSql = where.AddTemplate(@"SELECT * FROM Product /**where**/ /**orderby**/");
            return _context.Query<Product>(strSql.RawSql, strSql.Parameters);
        }

        public async Task<IEnumerable<Product>> FetchAsync(SqlBuilder where)
        {
            var strSql = where.AddTemplate(@"SELECT * FROM Product /**where**/ /**orderby**/");
            return await _context.QueryAsync<Product>(strSql.RawSql, strSql.Parameters);
        }

        public IEnumerable<T> Fetch<T>(string sql, SqlBuilder where, bool orderBy = true)
        {
            var _sql = orderBy ? $"{sql} /**where**/ /**orderby**/" : $"{sql} /**where**/";
            var strSql = where.AddTemplate(_sql);
            return _context.Query<T>(strSql.RawSql, strSql.Parameters);
        }

        public async Task<IEnumerable<T>> FetchAsync<T>(string sql, SqlBuilder where, bool orderBy = true)
        {
            var _sql = orderBy ? $"{sql} /**where**/ /**orderby**/" : $"{sql} /**where**/";
            var strSql = where.AddTemplate(_sql);
            return await _context.QueryAsync<T>(strSql.RawSql, strSql.Parameters);
        }

        public async Task<Page<Product>> PageAsync(long pageIndex, long pageSize, SqlBuilder builder)
        {
            var strSql = "SELECT * FROM Product";
            return await PageAsync<Product>(strSql, pageIndex, pageSize, builder);
        }

        public async Task<Page<T>> PageAsync<T>(string sql, long pageIndex, long pageSize, SqlBuilder builder)
        {
            var strSql = builder.AddTemplate($"{sql} /**where**/ /**orderby**/");
            return await _context.PageAsync<T>(pageIndex, pageSize, strSql.RawSql, strSql.Parameters);
        }

        public async Task<SqlMapper.GridReader> QueryMultipleAsync(string sql, object param = null)
        {
            return await _context.QueryMultipleAsync(sql, param);
        }

        public Task<Page<Product>> PageAsync<Product>(long pageIndex, long pageSize, SqlBuilder builder)
        {
            throw new NotImplementedException();
        }
    }
}
