namespace DummyApiExample.Api.Options;

public class DummyApiOptions
{
    public const string DummyApi = "DummyApi";
    
    public string BaseUrl { get; set; } = string.Empty;
    public string ApiKey { get; set; } = string.Empty;
}