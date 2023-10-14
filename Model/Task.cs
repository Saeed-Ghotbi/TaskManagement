namespace TaskManagement.Model
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public int Assignment { get; set; }
        public int Status { get; set; }
        public bool Seen { get; set; }
        public DateTime CDT { get; set; } = DateTime.Now;
        public DateTime MDT { get; set; }
    }
}
