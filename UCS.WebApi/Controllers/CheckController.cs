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


    [Authorize(ERole.Admin)]
    [HttpGet("GetDataAdmin")]
    public IActionResult GetDataAdmin()
    {

        return Ok();
    }

    [Authorize(ERole.Teacher)]
    [HttpGet("GetDataTeacher")]
    public IActionResult GetDataTeacher()
    {

        return Ok();
    }

    [Authorize(ERole.Student)]
    [HttpGet("GetDataStudent")]
    public IActionResult GetDataStudent()
    {

        return Ok();
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
            StartDateTime = x.StartDatetime,
            TimeLimit = x.TimeLimitDatetime,
            TopicInfo = _catalogService.GetTopic(x.TopicId),
            User = x.User,
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