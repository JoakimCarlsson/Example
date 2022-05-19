using System.Text.Json;

namespace DummyApiExample.Api.Extensions;

public static class HttpClientExtensions
{
    public static async Task<TResponse> GetAsObjectAsync<TResponse>(this HttpClient httpClient, string requestUri, CancellationToken cancellationToken = default)
    {
        var options = new JsonSerializerOptions {PropertyNameCaseInsensitive = true};
        var response = await httpClient.GetAsync(requestUri, cancellationToken);
        var content = await response.Content.ReadAsStringAsync(cancellationToken);
        if (content is null)
            throw new ArgumentNullException(nameof(content));
        
        var httpResponse = JsonSerializer.Deserialize<TResponse>(content, options);
        if (httpResponse is null)
            throw new ArgumentNullException(nameof(httpResponse));

        return httpResponse;
    }
}