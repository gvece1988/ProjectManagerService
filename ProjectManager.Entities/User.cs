using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProjectManager.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string EmployeeId { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [NotMapped]
        public string FullName { get { return $"{FirstName}{(LastName != null ? $"{ LastName}" : string.Empty)}"; } }
    }
}
