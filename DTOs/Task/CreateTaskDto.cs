namespace TaskManagement.DTOs.Task
{
    public class CreateTaskDto
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public int SubjectId { get; set; }
        public int StatusId { get; set; }
        public int AssignmentId { get; set; }
    }
}
