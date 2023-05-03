using Dapper;
using DapperSample.Models;
using DapperSample.Repository;
using DapperSample.Service;
using Lucene.Net.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService )
        {
            _productService = productService;
        }

        //商品列表
        [HttpGet]
        public async Task<IEnumerable<Product>> ProductList(DateTime? startDate, DateTime? endDate, int pageIndex = 1, int pageSize = 10, string keyword = "")
        {
            var builder = new SqlBuilder();

            if (startDate.HasValue)
            {
                builder.Where("CreateTime>=@startDate", new { startDate = startDate.Value });
            }
            if (endDate.HasValue)
            {
                builder.Where("CreateTime<@endDate", new { endDate = endDate.Value.AddDays(1) });
            }

            builder.OrderBy("CreateTime DESC");

            var list = await _productService.PageAsync(pageIndex, pageSize, builder);

            return list.Items;
            
        }

        //添加商品
        [HttpPost]
        public async Task<int> InsertAsync(Product product)
        {
            return await _productService.InsertAsync(product);
        }

        //[HttpPost]
        //public async Task<bool> AddAsync(Product product)
        //{
        //    return await _productService.AddProduct(product);
        //}

    }

}
