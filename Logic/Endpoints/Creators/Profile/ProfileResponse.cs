using Infrastructure.Routes;
using Microsoft.AspNetCore.Identity;

namespace CourseManagement.Logic.Endpoints.Creators.Profile
{
    public class ProfileResponse
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
        public string Website { get; set; }
    }
}
