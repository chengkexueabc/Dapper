using Dapper;
using DapperSample.Dapper;
using DapperSample.Models;
using DapperSample.Repository;
using DapperSample.Unit;

namespace DapperSample.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        //private readonly IUnitOfWorkFactory _uowFactory;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            //_uowFactory = uowFactory;
        }

        //public async Task<bool> AddProduct(Product productInfo)
        //{
        //    var result = false;
        //    using (var uow = _uowFactory.Create())
        //    {
        //        //添加产品
        //        await _productRepository.InsertAsync(productInfo);

        //        //添加Sku库存售价

        //        //await _context.InsertAsync(skuList);

        //        uow.SaveChanges();
        //        result = true;
        //    }
        //    return result;
        //}

        public async Task<int> InsertAsync(Product product)
        {
            return await _productRepository.InsertAsync(product);
        }

        public async Task<Page<Product>> PageAsync(long pageIndex, long pageSize, SqlBuilder builder)
        {
            return await _productRepository.PageAsync(pageIndex, pageSize, builder);
        }
    }
}
