using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace UCS.DbProvider.Models;

public class RegisterSession
{
    public Guid Id { get; set; }
    
    public DateTime SessionCreated { get; set; }
    public DateTime SessionExpired { get; set; }
    
    public int GroupId { get; set; }
    public Group Group { get; set; }

    [JsonIgnore]
    [IgnoreDataMember]
    public virtual ICollection<User> RegisteredUsers { get; set; }
}