using Microsoft.EntityFrameworkCore;
using ProjectManager.Entities;

namespace ProjectManager.DataAccess
{
    public interface IProjectManagerContext 
    {
        DbSet<Project> Projects { get; set; }
        DbSet<Task> Tasks { get; set; }
        DbSet<User> Users { get; set; }

        int SaveChanges();
    }
}