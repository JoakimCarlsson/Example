namespace DummyApiExample.Api.Response;

public sealed record UserResponse(
    string Id,
    string Title,
    string FirstName,
    string LastName,
    string Picture
);