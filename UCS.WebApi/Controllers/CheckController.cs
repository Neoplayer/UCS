using Microsoft.AspNetCore.Mvc;
using UCS.WebApi.Helpers;
using UCS.WebApi.Models;

namespace UCS.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CheckController : ControllerBase
{
    [Authorize(ERole.Student)]
    [HttpGet("GetData")]
    public IActionResult GetData()
    {

        return Ok();
    }
}