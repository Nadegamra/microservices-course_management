using FastEndpoints;

namespace CourseManagement.Endpoints.CourseRequirements.CourseRequirementUpdate
{
    public class CourseRequirementUpdateRequest
    {
        [FromClaim("UserId")]
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public int Id { get; set; }
        public required string CustomDescription { get; set; }
    }
}
