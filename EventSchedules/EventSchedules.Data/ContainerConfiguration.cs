using EventSchedules.Data.Contract;
using EventSchedules.Data.Repositiry;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;


namespace EventSchedules.Data
{
    public class ContainerConfiguration
    {
        public static void Configure(IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection.AddScoped<IContextManager, ContextManager>();
            serviceCollection.AddScoped<IEventRepo, EventRepo>();
            serviceCollection.AddScoped<IUserRepo, UserRepo>();
            serviceCollection.AddDbContext<EventShedulesDbContext>(option => option.UseSqlServer(connectionString));
        }
    }
}
