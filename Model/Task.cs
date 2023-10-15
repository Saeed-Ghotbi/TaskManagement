namespace TaskManagement.Model
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public bool Seen { get; set; } = false;
        public DateTime CDT { get; set; } = DateTime.Now;
        public DateTime MDT { get; set; }


        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public int StatusId { get; set; }
        public Status Status { get; set; }

        public int AssignmentId { get; set; }
        public User Assignment { get; set; }
    }
}
