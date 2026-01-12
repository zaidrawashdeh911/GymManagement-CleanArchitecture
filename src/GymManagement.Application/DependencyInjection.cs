// using GymManagement.Application.Services;

using GymManagement.Application.Subscriptions.Commands.CreateSubscription;
using Microsoft.Extensions.DependencyInjection;

namespace GymManagement.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // services.AddScoped<ISubscriptionsWriteService, SubscriptionsWriteService>();
        
        // will scan the assembly where the dependency injection type is. (where all the requests and request handlers are)
        // after scanning will look for all IRequest Interfaces and IRequest Hanlder Interfaces and will wire up everything together 
        // so we can simply call Send from the controller    
        services.AddMediatR(options =>
        {
            options.RegisterServicesFromAssemblyContaining(typeof(DependencyInjection));
        });
        return services;
    }
}