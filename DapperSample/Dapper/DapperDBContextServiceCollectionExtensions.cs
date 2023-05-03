namespace DapperSample.Dapper
{
    public static class DapperDBContextServiceCollectionExtensions
    {
        public static IServiceCollection AddDapperDBContext<T>(this IServiceCollection services, Action<DapperDBContextOptions> setupAction) where T : DapperDBContext
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            if (setupAction == null) throw new ArgumentNullException(nameof(setupAction));

            services.Configure(setupAction);
            services.AddScoped<DapperDBContext, T>();
            return services;
        }
    }
}
