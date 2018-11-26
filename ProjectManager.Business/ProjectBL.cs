using Microsoft.EntityFrameworkCore;
using ProjectManager.DataAccess;
using ProjectManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManager.Business
{
    public class ProjectBL : IProjectBL
    {
        private readonly IProjectManagerContext _context;

        public ProjectBL(IProjectManagerContext context)
        {
            _context = context;
        }

        public Project GetProjectById(int id)
        {
            return _context.Projects                
                .FirstOrDefault(m => m.Id == id);                
        }

        public IEnumerable<Project> GetProjects()
        {
            return _context.Projects
                .Include(m => m.Tasks)
                .Include(m => m.Manager)
                .Select(m => new Project
                {
                    Id = m.Id,
                    Title = m.Title,
                    StartDate = m.StartDate,
                    EndDate = m.EndDate,
                    ManagerId = m.ManagerId,
                    Manager = m.Manager,
                    Priority = m.Priority,
                    Tasks = m.Tasks.Select(n => new Task
                    {
                        Id = n.Id,
                        IsCompleted = n.IsCompleted
                    }).ToList()
                })
                .OrderByDescending(m => m.Id)
                .ToList();
        }

        public IEnumerable<Project> SearchProjects(string searchText)
        {
            return _context.Projects
                .Where(m => searchText == null || m.Title.Contains(searchText))
                .OrderByDescending(m => m.Id)
                .ToList();
        }

        public int AddProject(Project project)
        {
            _context.Projects.Add(project);
            _context.SaveChanges();
            return project.Id;
        }

        public Project UpdateProject(Project project)
        {
            _context.Projects.Update(project);
            _context.SaveChanges();
            return project;
        }

        public void DeleteProject(int id)
        {
            var project = _context.Projects.SingleOrDefault(m => m.Id == id);
            _context.Projects.Remove(project);
            _context.SaveChanges();
        }
    }
}
