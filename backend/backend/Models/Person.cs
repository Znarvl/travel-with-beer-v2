namespace backend.Models
{
    public class Person
    {
        public int Id { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required int CansOwned { get; set; }
        public required int TotalMeters { get; set; }
    }
}
