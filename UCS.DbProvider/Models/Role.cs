using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace UCS.DbProvider.Models
{
    public class Role
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; }
    }
}
