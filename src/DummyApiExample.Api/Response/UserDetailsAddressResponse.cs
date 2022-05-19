namespace DummyApiExample.Api.Response;

public record UserDetailsAddressResponse(
    string Street,
    string City,
    string State,
    string Country,
    string Timezone
);
