namespace DummyApiExample.Api.Response;

public sealed record BasePaginationResponse<T>(
    IReadOnlyList<T> Data,
    int Total,
    int Page,
    int Limit
);