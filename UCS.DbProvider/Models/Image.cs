using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace UCS.DbProvider.Models;

public class Image
{
    public Guid Id { get; set; }

    public string Path { get; set; }
    public string UploadDateTime { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public int Size { get; set; }

    [JsonIgnore]
    public ICollection<Question> Questions { get; set; }
}