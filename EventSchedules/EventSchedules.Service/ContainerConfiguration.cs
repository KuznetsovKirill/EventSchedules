using EventSchedules.Service.Settings;
using Microsoft.Extensions.DependencyInjection;
using System;
using EventSchedules.Data.Contract;
using EventSchedules.Service.Contract;
using EventSchedules.Service.Wrapper.Contract;
using EventSchedules.Service.Wrapper;

namespace EventSchedules.Service
{
    public class ContainerConfiguration
    {
        public static void Configure(IServiceCollection serviceCollection, APISettings settings)
        {
            serviceCollection.AddAutoMapper(typeof(ContainerConfiguration));

            Data.ContainerConfiguration.Configure(serviceCollection, settings.ConnectionString);
            serviceCollection.AddSingleton(settings);
            serviceCollection.AddScoped<IEventService, EventService>();
            serviceCollection.AddScoped<IHashWrapeer, HashWrapper>();
            serviceCollection.AddScoped<IAuthenticateService, AuthenticateService>();
            serviceCollection.AddScoped<IUserService, UserService>();
        }
    }
}
