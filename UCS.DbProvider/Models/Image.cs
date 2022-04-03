using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace UCS.DbProvider.Models;

public class Image
{
    public Guid Id { get; set; }

    public string Path { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public DateTime UploadDateTime { get; set; }
    public int Size { get; set; }
    public byte[] ImageBytes { get; set; }

    [JsonIgnore]
    public virtual ICollection<Question> Questions { get; set; }
}