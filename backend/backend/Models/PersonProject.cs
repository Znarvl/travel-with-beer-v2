using Microsoft.Spatial;
namespace backend.Models
{
    public class PersonProject
    {
        public required int PersonId { get; set; }
        public required int ProjectId { get; set; }
        public required int CansInProject { get; set; }
        public required int TotalMetersInProject { get; set; }
       // public required GeographyPoint StartLocation { get; set; } // Replace 'geography' with the actual data type
       // public required GeographyPoint EndLocation { get; set; }   // Replace 'geography' with the actual data type
       // public required GeographyLineString GeoRoute { get; set; }       // Replace 'geography' with the actual data type


        // Navigation properties
        public required Person Person { get; set; }
        public required Project Project { get; set; }
    }
}
