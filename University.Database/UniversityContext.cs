using Microsoft.EntityFrameworkCore;
using University.Database.Models;

namespace University.Database {

    public class UniversityContext : DbContext {

        public UniversityContext(DbContextOptions<UniversityContext> options) : base(options) { }

        public DbSet<Group> Groups { get; set; }

        public DbSet<GroupSubject> GroupSubjects { get; set; }

        public DbSet<Mark> Marks { get; set; }

        public DbSet<Notification> Notifications { get; set; }

        public DbSet<NotificationStudent> NotificationStudents { get; set; }
        
        public DbSet<Subject> Subjects { get; set; }

        public DbSet<User> Users { get; set; }
        
        public DbSet<UserGroup> UserGroups  { get; set; }
        
        public DbSet<UserMark> UserMarks { get; set; }
        
        public DbSet<UserRole> UserRoles { get; set; }
    }
    
    
}