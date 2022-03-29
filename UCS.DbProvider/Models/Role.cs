using System.Collections.Generic;

namespace UCS.DbProvider.Models
{
    public class Role
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
