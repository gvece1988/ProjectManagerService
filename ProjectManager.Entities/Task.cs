using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManager.Entities
{
    public class Task
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Priority { get; set; }
        public bool IsParentTask { get; set; }
        public bool IsCompleted { get; set; }

        public int? ParentTaskId { get; set; }
        public Task ParentTask { get; set; }

        public int? ProjectId { get; set; }
        public Project Project { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }
    }
}
