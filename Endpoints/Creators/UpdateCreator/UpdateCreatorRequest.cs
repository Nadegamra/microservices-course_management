using FastEndpoints;

namespace CourseManagement.Endpoints.Creators.UpdateCreator
{
    public class UpdateCreatorRequest
    {
        [FromClaim("UserId")]
        public int UserId { get; set; }
        public string Bio { get; set; }
        public string Website { get; set; }
    }
}
