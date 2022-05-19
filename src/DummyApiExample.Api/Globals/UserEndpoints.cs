namespace DummyApiExample.Api.Globals;

public static class UserEndpoints
{
    public static string GetAll(int limit = 50, int page = 0) => $"user?limit={limit}&page={page}";
}