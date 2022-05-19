namespace DummyApiExample.Api.Response;

public record UserDetailsResponse(
    string Id,
    string Title,
    string FirstName,
    string LastName,
    string Picture,
    string Gender,
    string Email,
    DateTime DateOfBirth,
    string Phone,
    UserDetailsAddressResponse Location,
    DateTime RegisterDate,
    DateTime UpdatedDate
);
