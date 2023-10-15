namespace TaskManagement.DTOs.Task
{
    public class TaskDto
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime CDT { get; set; }


        public Model.Subject Subject { get; set; }
        public Model.Status Status { get; set; }
        public Model.User Assignment { get; set; }

    }
}
