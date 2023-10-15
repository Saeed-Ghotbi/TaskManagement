using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagement.Model
{
    public class User
    {
        public int Id { get; set; }
        public DateTime LastLogin { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public DateTime CDT { get; set; } = DateTime.Now; 
        public int FailedLogin { get; set; }

        public ProfileUser? ProfileUser { get; set; }
        public ICollection<Task>? Tasks { get; set; }
    }
}
