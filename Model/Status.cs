namespace TaskManagement.Model
{
    public class Status
    {
        public int Id { get; set; }
        public int Creator { get; set; }
        public string Title { get; set; }
        public DateTime CDT { get; set; } = DateTime.Now;
        public DateTime MDT { get; set; }
    }
}
