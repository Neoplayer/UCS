using System.Net;
using Microsoft.AspNetCore.Mvc;
using UCS.WebApi.Services;

namespace UCS.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ImageController : ControllerBase
{
    IImageService _imageService;
    
    public ImageController(IImageService imageService)
    {
        _imageService = imageService;
    }
    
    
    [HttpPost("Upload")]
    public async Task<IActionResult> AddFile(IFormFile uploadedFile)
    {
        if (uploadedFile != null)
        {
            await using var memoryStream = new MemoryStream();
            await uploadedFile.CopyToAsync(memoryStream);
            var res = _imageService.UploadImage(memoryStream.ToArray());
    
            return Ok(res);
        }
            
        return BadRequest();
    }
 
    [HttpGet("GetFileByGuid")]
    public FileContentResult GetFiles(Guid imageGuid)
    {
        var image = _imageService.GetImage(imageGuid);
        
        return new FileContentResult(image, "image/jpg");
    }
}