using UCS.DbProvider;
using UCS.DbProvider.Models;

namespace UCS.WebApi.Services;

public interface IImageService
{
    Guid UploadImage(byte[] user);
    byte[]? GetImage(Guid imageGuid);
}

public class ImageService : IImageService
{
    public Guid UploadImage(byte[] imageBytes)
    {
        using MainContext context = new MainContext();

        var image = new Image()
        {
            Id = Guid.NewGuid(), 
            ImageBytes = imageBytes,
            UploadImageDateTime = DateTime.Now
        };
        
        context.Images.Add(image);
        context.SaveChangesAsync();

        return image.Id;
    }

    public byte[]? GetImage(Guid imageGuid)
    {
        using MainContext context = new MainContext();

        var image = context.Images.FirstOrDefault(x => x.Id == imageGuid);

        return image?.ImageBytes;
    }
}