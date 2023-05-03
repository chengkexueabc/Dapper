using Microsoft.Extensions.Options;

namespace DapperSample.Dapper
{
    public class DapperDBContextOptions : IOptions<DapperDBContextOptions>
    {
        public string Configuration { get; set; }
        public DapperDBContextOptions Value { get { return this; } }
    }
}
