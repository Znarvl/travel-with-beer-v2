namespace backend.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public required string Name { get; set; }

        public required ICollection<PersonProject> PersonProjects { get; set; }
        public ICollection<ProjectMessage>? ProjectMessages { get; set; }
    }
}
