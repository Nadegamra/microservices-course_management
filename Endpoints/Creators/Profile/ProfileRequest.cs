using FastEndpoints;

namespace CourseManagement.Endpoints.Creators.Profile
{
    public class ProfileRequest
    {
        [FromClaim("UserId")]
        public int UserId { get; set; }
    }
}
