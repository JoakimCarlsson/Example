using DummyApiExample.Api.Options;
using Microsoft.AspNetCore.Mvc;

namespace DummyApiExample.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DummyController : ControllerBase
{
    private readonly ILogger<DummyController> _logger;
    private readonly IDummyApiServiceHelper _dummyApiServiceHelper;

    public DummyController(ILogger<DummyController> logger, IDummyApiServiceHelper dummyApiServiceHelper)
    {
        _logger = logger;
        _dummyApiServiceHelper = dummyApiServiceHelper;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll(CancellationToken cancellationToken)
    {
        var result = await _dummyApiServiceHelper.GetUsersAsync(cancellationToken);
        if (result is not null)
            return Ok(result);

        return NotFound();
    }
}