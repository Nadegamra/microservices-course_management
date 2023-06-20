using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.Creators.Profile
{
    public class ProfileRequest
    {
        [FromClaim("UserId")]
        public int UserId { get; set; }
    }
}
