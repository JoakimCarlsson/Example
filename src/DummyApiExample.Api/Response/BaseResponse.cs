namespace DummyApiExample.Api.Response;

public sealed record BaseResponse<T>(
    IReadOnlyList<T> Data,
    int Total,
    int Page,
    int Limit
);