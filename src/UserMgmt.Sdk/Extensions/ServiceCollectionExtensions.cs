using Microsoft.Extensions.DependencyInjection;

namespace UserMgmt.Sdk.Services;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddUserMgmtSdk(this IServiceCollection services, string baseUrl)
    {
        services.AddHttpClient<IUserMgmtClient, UserMgmtClient>(c =>
        {
            c.BaseAddress = new Uri(baseUrl);
        });
        return services;
    }
}
