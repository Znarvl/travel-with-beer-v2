namespace backend.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required int CansOwned { get; set; }
        public required int TotalMeters { get; set; }

        public ICollection<PersonProject>? PersonProjects { get; set; }
        public ICollection<ProjectMessage>? ProjectMessages { get; set; }

    }
}
