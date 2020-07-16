using Microsoft.Extensions.DependencyInjection;

namespace Holec.SkoleniUtils
{
    public static class DbExtensions
    {
        public static void AddDatabase(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<UnitOfWork>();
        }
    }
}