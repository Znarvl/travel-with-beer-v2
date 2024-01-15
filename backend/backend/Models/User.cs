namespace backend.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required int Cans { get; set; }
        public required int Meters { get; set; }

    }
}
