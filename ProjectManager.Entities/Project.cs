using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProjectManager.Entities
{
    [Serializable]
    public class Project
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Priority { get; set; }

        [ForeignKey("Manager")]
        public int? ManagerId { get; set; }
        public User Manager{ get; set; }
        public List<Task> Tasks { get; set; }
    }
}
