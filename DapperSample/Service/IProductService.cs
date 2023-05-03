using Dapper;
using DapperSample.Dapper;
using DapperSample.Models;

namespace DapperSample.Service
{
    public interface IProductService
    {
        //Task<bool> AddProduct(Product productInfo);
        Task<Page<Product>> PageAsync(long pageIndex, long pageSize, SqlBuilder builder);

        Task<int> InsertAsync(Product product);

    }
}
