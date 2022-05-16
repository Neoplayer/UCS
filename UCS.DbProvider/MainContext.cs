using Microsoft.EntityFrameworkCore;
using UCS.DbProvider.Models;

namespace UCS.DbProvider
{
    public class MainContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionType> QuestionTypes { get; set; }
        public DbSet<QuestionTheme> QuestionThemes { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<TestSession> TestSessions { get; set; }
        public DbSet<SessionAnswer> SessionAnswers { get; set; }
        public DbSet<Image> Images { get; set; }
        //public DbSet<RegisterSession> RegisterSessions { get; set; }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<User>()
        //         .HasOne(p => p.RegistrationSession)
        //         .WithMany(b => b.RegisteredUsers);
        // }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=89.108.77.44;Port=5432;Database=UCSDB;Username=postgres;Password=kah4haiPeaNg");
    }
}
