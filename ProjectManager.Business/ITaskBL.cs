using System.Collections.Generic;
using ProjectManager.Entities;

namespace ProjectManager.Business
{
    public interface ITaskBL
    {
        int AddTask(Task item);
        void EndTask(int id);
        IEnumerable<Task> GetTasks();
        IEnumerable<Task> GetParentTasks();
        IEnumerable<Task> GetTasksByProjectId(int projectId);
        Task GetTaskById(int Id);
        void UpdateTask(Task item);
    }
}