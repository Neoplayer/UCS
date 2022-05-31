using Microsoft.AspNetCore.Mvc;
using UCS.DbProvider.Models;
using UCS.WebApi.Dto.Check;
using UCS.WebApi.Dto.Session;
using UCS.WebApi.Helpers;
using UCS.WebApi.Models;
using UCS.WebApi.Services;

namespace UCS.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CheckController : ControllerBase
{
    ICheckService _checkService;
    ICatalogService _catalogService;

    public CheckController(ICheckService checkService, ICatalogService catalogService)
    {
        _catalogService = catalogService;
        _checkService = checkService;
    }


    [Authorize(ERole.Teacher)]
    [HttpGet("GetGroups")]
    public IActionResult GetGroups()
    {
        var user = HttpContext.Items["User"] as User;

        if (user == null)
        {
            return (BadRequest("Auth error!"));
        }

        var groups = _checkService.GetGroups(user);

        return Ok(groups.Select(x => new GroupResponse()
        {
            Success = true,
            Name = x.Name,
            Subjects = x.Subjects,
            Users = x.Users
        }).ToList());
    }

    

    [Authorize(ERole.Teacher)]
    [HttpPost("SetTestResult")]
    public IActionResult SetTestResult(SetResultRequest model)
    {
        var res = _checkService.SetTestResult(model.SessionId, model.Result, model.Comment);

        return res ? Ok(new { Success = res }) : BadRequest("Session not found");
    }

    [Authorize(ERole.Teacher)]
    [HttpGet("GetTestsToCheck")]
    public IActionResult GetTestsToCheck()
    {
        var user = HttpContext.Items["User"] as User;

        if (user == null)
        {
            return (BadRequest("Auth error!"));
        }

        var sessions = _checkService.GetTestsToCheck(user.Id);

        return Ok(sessions.Select(x => new SessionResponse()
        {
            Success = true,
            Id = x.Id,
            StartDateTime = x.StartDatetime,
            TimeLimit = x.TimeLimitDatetime,
            TopicInfo = _catalogService.GetTopic(x.TopicId),
            User = x.User,
            Result = x.Result,
            Comment = x.Comment,
            Questions = x.Answers.Select(x => new QuestionResponse()
            {
                QuestionId = x.QuestionId,
                QuestionImageId = x.Question.ImageId,
                AnswerImageId = x.ImageId,
                Body = x.Question.Body,
                HintImageId = x.Question.HintImageId
            }).ToList()
        }));
    }

    [Authorize(ERole.Teacher)]
    [HttpGet("GetArchive")]
    public IActionResult GetArchive()
    {
        var user = HttpContext.Items["User"] as User;

        if (user == null)
        {
            return (BadRequest("Auth error!"));
        }

        var sessions = _checkService.GetArchive(user.Id);

        return Ok(sessions.Select(x => new SessionResponse()
        {
            Success = true,
            Id = x.Id,
            StartDateTime = x.StartDatetime,
            TimeLimit = x.TimeLimitDatetime,
            TopicInfo = _catalogService.GetTopic(x.TopicId),
            User = x.User,
            Result = x.Result,
            Comment = x.Comment,
            Questions = x.Answers.Select(x => new QuestionResponse()
            {
                QuestionId = x.QuestionId,
                QuestionImageId = x.Question.ImageId,
                AnswerImageId = x.ImageId,
                Body = x.Question.Body,
                HintImageId = x.Question.HintImageId
            })
            .ToList()
        }));
    }


    [HttpGet("GetCheckedTests")]
    public IActionResult GetCheckedTests()
    {
        var user = HttpContext.Items["User"] as User;

        if (user == null)
        {
            return (BadRequest("Auth error!"));
        }

        var sessions = _checkService.GetCheckedTests(user.Id);

        return Ok(sessions.Select(x => new SessionResponse()
        {
            Success = true,
            Id = x.Id,
            StartDateTime = x.StartDatetime,
            TimeLimit = x.TimeLimitDatetime,
            TopicInfo = _catalogService.GetTopic(x.TopicId),
            User = x.User,
            Result = x.Result,
            Comment = x.Comment,
            Questions = x.Answers.Select(x => new QuestionResponse()
            {
                QuestionId = x.QuestionId,
                QuestionImageId = x.Question.ImageId,
                AnswerImageId = x.ImageId,
                Body = x.Question.Body
            }).ToList()
        }));
    }
}