using Microsoft.EntityFrameworkCore;
using ProjectManager.Entities;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ProjectManager.DataAccess
{
    public class ProjectManagerContext : DbContext, IProjectManagerContext
    {
        public ProjectManagerContext(DbContextOptions<ProjectManagerContext> options)
            : base(options)
        {            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            base.OnModelCreating(modelBuilder);
        }        

        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
