using Microsoft.AspNetCore.Mvc;

namespace DummyApiExample.Api.Controllers;

public class DummyViewController : Controller
{
    private readonly IDummyApiServiceHelper _dummyApiServiceHelper;

    public DummyViewController(IDummyApiServiceHelper dummyApiServiceHelper)
    {
        _dummyApiServiceHelper = dummyApiServiceHelper;
    }
    
    [HttpGet]
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var result = await _dummyApiServiceHelper.GetUsersAsync(30, 0, cancellationToken);
        
        return View(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> UserDetails(string id, CancellationToken cancellationToken)
    {
        var result = await _dummyApiServiceHelper.GetByIdAsync(id, cancellationToken);
        return View(result);
    }
}