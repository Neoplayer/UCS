using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace UCS.DbProvider.Models;

public class Image
{
    public Guid Id { get; set; }

    public string Path { get; set; }
    public DateTime UploadImageDateTime { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public int Size { get; set; }
    public byte[] ImageBytes { get; set; }

    [JsonIgnore]
    public ICollection<Question> Questions { get; set; }
}