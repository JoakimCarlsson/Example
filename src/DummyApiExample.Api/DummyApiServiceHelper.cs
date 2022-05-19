using System.Text.Json;
using DummyApiExample.Api.Extensions;
using DummyApiExample.Api.Globals;
using DummyApiExample.Api.Response;

namespace DummyApiExample.Api;

public interface IDummyApiServiceHelper
{
    public Task<BaseResponse<UserResponse>?> GetUsersAsync(int limit, int page, CancellationToken cancellationToken = default);
    public Task<UserDetailsResponse?> GetByIdAsync(string userId, CancellationToken cancellationToken = default);

}

public class DummyApiServiceHelper : IDummyApiServiceHelper
{
    private readonly ILogger<DummyApiServiceHelper> _logger;
    private readonly HttpClient _httpClient;

    public DummyApiServiceHelper(ILogger<DummyApiServiceHelper> logger, IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _httpClient = httpClientFactory.CreateClient("dummy");
    }
    
    public async Task<BaseResponse<UserResponse>?> GetUsersAsync(int limit, int page, CancellationToken cancellationToken = default)
    {
        try
        {
            var response = await _httpClient.GetAsObjectAsync<BaseResponse<UserResponse>>(UserEndpoints.GetAll(limit, page), cancellationToken);
            return response;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to get users.");
            throw;
        }
    }

    public async Task<UserDetailsResponse?> GetByIdAsync(string userId, CancellationToken cancellationToken = default)
    {
        try
        {
            var response = await _httpClient.GetAsObjectAsync<UserDetailsResponse>(UserEndpoints.GetById(userId), cancellationToken);
            return response;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to get user details.");
            throw;
        }
    }
}