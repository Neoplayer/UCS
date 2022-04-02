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

        _testSessionService.StartSession(user, topicId);
        
        return Ok();
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
        
        return Ok();
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
        
        _testSessionService.GetActiveSession(user);
        
        return Ok();
    }
    [Authorize]
    [HttpPost("SendAnswer")]
    public IActionResult SendAnswer(AnswerData data)
    {
        var user = HttpContext.Items["User"] as User;

        if (user == null)
        {
            return (BadRequest("Auth error!"));
        }
        
        _testSessionService.SendAnswer(user, data.QuestionId, data.Image);
        
        return Ok();
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

        _testSessionService.RemoveAnswer(user, questionId);
        
        return Ok();
    }
}