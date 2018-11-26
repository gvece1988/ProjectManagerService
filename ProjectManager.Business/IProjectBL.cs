using System.Collections.Generic;
using ProjectManager.Entities;

namespace ProjectManager.Business
{
    public interface IProjectBL
    {
        int AddProject(Project user);
        Project GetProjectById(int id);
        void DeleteProject(int id);
        IEnumerable<Project> GetProjects();
        IEnumerable<Project> SearchProjects(string searchText);
        Project UpdateProject(Project user);
    }
}