using Microsoft.AspNetCore.Mvc;
using UCS.DbProvider.Models;
using UCS.WebApi.Dto;
using UCS.WebApi.Dto.Session;
using UCS.WebApi.Helpers;
using UCS.WebApi.Services;

namespace UCS.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TestingController : ControllerBase
{
    ICatalogService _catalogService;
    ITestSessionService _testSessionService;

    public TestingController(ITestSessionService testSessionService, ICatalogService catalogService)
    {
        _catalogService = catalogService;
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
            return Ok(new { Success = false, Message = "Session already started" });
        }

        return Ok(new SessionResponse()
        {
            Success = true,
            StartDateTime = session.StartDatetime,
            TimeLimit = session.TimeLimitDatetime,
            TopicInfo = _catalogService.GetTopic(session.TopicId),
            Questions = session.Answers.Select(x => new QuestionResponse()
            {
                QuestionId = x.QuestionId,
                QuestionImageId = x.Question.ImageId,
                AnswerImageId = x.ImageId,
                Body = x.Question.Body
            }).ToList()
        });
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

        return Ok(new { Success = true });
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

        if (session == null)
        {
            return Ok(new { Success = false, Message = "No active sessions" });
        }

        return Ok(new SessionResponse()
        {
            Success = true,
            StartDateTime = session.StartDatetime,
            TimeLimit = session.TimeLimitDatetime,
            TopicInfo = _catalogService.GetTopic(session.TopicId),
            Questions = session.Answers.Select(x => new QuestionResponse()
            {
                QuestionId = x.QuestionId,
                QuestionImageId = x.Question.ImageId,
                AnswerImageId = x.ImageId,
                Body = x.Question.Body
            }).ToList()
        });
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

        return Ok(new { Success = res });
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

        return Ok(new { Success = res });
    }
}