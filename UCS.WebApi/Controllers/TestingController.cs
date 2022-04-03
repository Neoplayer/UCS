using Microsoft.AspNetCore.Mvc;
using UCS.DbProvider.Models;
using UCS.WebApi.Dto;
using UCS.WebApi.Helpers;
using UCS.WebApi.Services;

namespace UCS.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TestingController : ControllerBase
{
    ITestSessionService _testSessionService;

    public TestingController(ITestSessionService testSessionService)
    {
        _testSessionService = testSessionService;
    }

    [Authorize]
    [HttpGet("StartSession")]
    public IActionResult StartSession(int topicId)
    {
        var user = HttpContext.Items["User"] as User;

        if (user == null)
        {
            return (BadRequest("Auth error!"));
        }

        var session = _testSessionService.StartSession(user, topicId);

        if (session == null)
        {

            return Ok(new { success = false, message = "Session already started" });
        }

        return Ok(new { success = true, session, questions = session.Answers.ToList() });
    }

    [Authorize]
    [HttpGet("FinishSession")]
    public IActionResult FinishSession()
    {
        var user = HttpContext.Items["User"] as User;

        if (user == null)
        {
            return (BadRequest("Auth error!"));
        }

        _testSessionService.FinishSession(user);

        return Ok(new { success = true });
    }

    [Authorize]
    [HttpGet("GetActiveSession")]
    public IActionResult GetActiveSession()
    {
        var user = HttpContext.Items["User"] as User;

        if (user == null)
        {
            return (BadRequest("Auth error!"));
        }

        var session = _testSessionService.GetActiveSession(user);

        return Ok(new { success = true, session, questions = session?.Answers?.ToList() });
    }

    [Authorize]
    [HttpPost("SendAnswer")]
    public IActionResult SendAnswer(int questionId, IFormFile file)
    {
        var user = HttpContext.Items["User"] as User;

        if (user == null)
        {
            return (BadRequest("Auth error!"));
        }

        var res = _testSessionService.SendAnswer(user, questionId, file.GetBytes().Result);

        return Ok(new { success = res });
    }

    [Authorize]
    [HttpGet("RemoveAnswer")]
    public IActionResult RemoveAnswer(int questionId)
    {
        var user = HttpContext.Items["User"] as User;

        if (user == null)
        {
            return (BadRequest("Auth error!"));
        }

        var res = _testSessionService.RemoveAnswer(user, questionId);

        return Ok(new { success = res });
    }
}