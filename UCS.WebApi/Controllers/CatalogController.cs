using Microsoft.AspNetCore.Mvc;
using UCS.DbProvider.Models;
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
    public IActionResult GetUserCatalog()
    {
        var user = HttpContext.Items["User"] as User;

        if (user == null)
        {
            return (BadRequest("Auth error!"));
        }

        var catalog = _catalogService.GetUserDataSubjectsByUser(user);
        
        return Ok(catalog);
    }
}