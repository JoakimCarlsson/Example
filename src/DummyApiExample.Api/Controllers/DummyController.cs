using Microsoft.AspNetCore.Mvc;

namespace DummyApiExample.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DummyController : ControllerBase
{
    private readonly IDummyApiServiceHelper _dummyApiServiceHelper;

    public DummyController(ILogger<DummyController> logger, IDummyApiServiceHelper dummyApiServiceHelper)
    {
        _dummyApiServiceHelper = dummyApiServiceHelper;
    }

    [HttpGet("user")]
    public async Task<ActionResult> GetAll([FromQuery]int limit, [FromQuery]int page, CancellationToken cancellationToken)
    {
        var result = await _dummyApiServiceHelper.GetUsersAsync(limit, page, cancellationToken);
        if (result is not null)
            return Ok(result);

        return NotFound();
    }
    
    [HttpGet("user/{id}")]
    public async Task<ActionResult> GetById(string id, CancellationToken cancellationToken)
    {
        var result = await _dummyApiServiceHelper.GetByIdAsync(id, cancellationToken);
        if (result is not null)
            return Ok(result);
        
        return NotFound();
    }
}