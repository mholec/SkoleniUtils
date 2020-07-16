using Microsoft.Extensions.DependencyInjection;

namespace SkoleniUtils
{
    public static class DbExtensions
    {
        public static void AddDatabase(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<UnitOfWork>();
        }
    }
}