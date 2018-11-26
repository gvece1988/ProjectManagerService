using System.Collections.Generic;
using System.Linq;
using ProjectManager.DataAccess;
using ProjectManager.Entities;
using Microsoft.EntityFrameworkCore;

namespace ProjectManager.Business
{
    public class TaskBL : ITaskBL
    {
        private readonly IProjectManagerContext _context;

        public TaskBL(IProjectManagerContext context)
        {
            _context = context;
        }

        public IEnumerable<Task> GetTasks()
        {
            return _context.Tasks.OrderByDescending(m => m.Id).ToArray();
        }

        public IEnumerable<Task> GetParentTasks()
        {
            return _context.Tasks
                .Where(m => m.IsParentTask)
                .OrderByDescending(m => m.Id).ToArray();
        }

        public IEnumerable<Task> GetTasksByProjectId(int projectId)
        {
            return _context.Tasks
                .Include(m => m.ParentTask)
                .Where(m => m.ProjectId == projectId)
                .OrderByDescending(m => m.Id).ToArray();
        }

        public Task GetTaskById(int Id)
        {
            var task = _context.Tasks
                .Include(m => m.User)
                .Include(m => m.Project)
                .Include(m => m.ParentTask)
                .FirstOrDefault(m => m.Id == Id);

            if (task.Project != null)
            {
                task.Project.Tasks = null;
            }
            return task;
        }

        public int AddTask(Task item)
        {
            _context.Tasks.Add(item);
            _context.SaveChanges();
            return item.Id;
        }

        public void UpdateTask(Task item)
        {
            var task = _context.Tasks.FirstOrDefault(m => m.Id == item.Id);

            task.Title = item.Title;
            task.Priority = item.Priority;
            task.StartDate = item.StartDate;
            task.EndDate = item.EndDate;
            task.ParentTaskId = item.ParentTaskId;
            task.UserId = item.UserId;
            task.ProjectId = item.ProjectId;           

            _context.SaveChanges();
        }

        public void EndTask(int id)
        {
            var task = _context.Tasks.FirstOrDefault(m => m.Id == id);
            task.IsCompleted = true;

            _context.SaveChanges();
        }
    }
}
