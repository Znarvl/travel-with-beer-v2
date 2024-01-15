namespace backend.Models
{
    public class ProjectMessage
    {
        public int MessageId { get; set; }
        public int ProjectId { get; set; }
        public int PersonId { get; set; }
        public string? Message { get; set; }
        public DateTime Timestamp { get; set; }

        // Navigation properties
        public required Project Project { get; set; }
        public required Person Person { get; set; }
    }
}
