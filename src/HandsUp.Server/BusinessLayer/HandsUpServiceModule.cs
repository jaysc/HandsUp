using Microsoft.Extensions.DependencyInjection;
namespace HandsUp.Server.BusinessLayer
{
    public static class BusinessLayerModule
    {
        public static IServiceCollection RegisterBusinessLayer(this IServiceCollection services)
        {
            services.AddScoped<IHandsUpEventServiceManager, HandsUpEventServiceManager>();

            return services;
        }
    }
}
