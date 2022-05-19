using DummyApiExample.Api.Options;

namespace DummyApiExample.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDummyApi(this IServiceCollection services, Action<DummyApiOptions> configure)
    {
        var options = new DummyApiOptions();
        configure(options);

        if (string.IsNullOrWhiteSpace(options.BaseUrl))
            throw new ArgumentNullException(options.BaseUrl, "BaseUrl is required");
        
        if (string.IsNullOrWhiteSpace(options.ApiKey))
            throw new ArgumentNullException(options.ApiKey, "ApiKey is required");
        
        services.AddHttpClient("dummy", client =>
        {
            client.BaseAddress = new Uri(options.BaseUrl);
            client.DefaultRequestHeaders.Add("app-id", options.ApiKey);
        });

        return services;
    }
}