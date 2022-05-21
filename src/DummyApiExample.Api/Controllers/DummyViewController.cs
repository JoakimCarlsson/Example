using Microsoft.AspNetCore.Mvc;

namespace DummyApiExample.Api.Controllers;

public class DummyViewController : Controller
{
    private readonly IDummyApiServiceHelper _dummyApiServiceHelper;

    public DummyViewController(IDummyApiServiceHelper dummyApiServiceHelper)
    {
        _dummyApiServiceHelper = dummyApiServiceHelper;
    }
    
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var result = await _dummyApiServiceHelper.GetUsersAsync(30, 0, cancellationToken);
        
        return View(result);
    }
}