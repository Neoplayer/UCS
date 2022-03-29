using Microsoft.EntityFrameworkCore;
using UCS.DbProvider.Models;

namespace UCS.DbProvider
{
    public class MainContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=89.108.77.44;Port=5432;Database=SiteDb;Username=postgres;Password=kah4haiPeaNg");
    }
}
