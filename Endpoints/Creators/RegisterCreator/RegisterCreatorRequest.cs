using FastEndpoints;

namespace CourseManagement.Endpoints.Creators.RegisterCreator
{
    public class RegisterCreatorRequest
    {
        [FromClaim("UserId")]
        public int Id { get; set; }
        [FromClaim("UserEmail")]
        public string Email { get; set; }
        [FromClaim("UserName")]
        public string Username { get; set; }
        public string Bio { get; set; }
        public string Website { get; set; }
    }
}
