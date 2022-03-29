namespace UCS.DbProvider.Models;
using System.Collections.Generic;

public class Image
{
    public int Id { get; set; }

    public string Path { get; set; }
    public string UploadDateTime { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public int Size { get; set; }

    public IEnumerable<Question> Questions { get; set; }
}