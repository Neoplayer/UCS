using Microsoft.AspNetCore.Mvc;
using UCS.WebApi.Helpers;
using UCS.WebApi.Models.User;
using UCS.WebApi.Services;

namespace UCS.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CatalogController : ControllerBase
{
    private ICatalogService _catalogService;

    public CatalogController(ICatalogService catalogService)
    {
        _catalogService = catalogService;
    }
    
    [Authorize]
    [HttpGet("GetUserCatalog")]
    public IActionResult GetUserData()
    {
        var user = HttpContext.Items["User"];

        if (user == null)
        {
            return (BadRequest("Auth error!"));
        }
        return Ok(user);
    }
}