using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace UCS.DbProvider.Models
{
    public class User
    {
        public int Id { get; set; }

        public Guid ImageId { get; set; }
        public Image Image { get; set; }

        public string Email { get; set; }
        public string Username { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public int Ages { get; set; }
        public DateTime RegistrationDate { get; set; }

        
        
        // public Guid RegistrationSessionId { get; set; }
        // public RegisterSession RegistrationSession { get; set; }
        
        
        [IgnoreDataMember]
        public virtual ICollection<Role> Roles { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<Group> Groups { get; set; }
    }
}
