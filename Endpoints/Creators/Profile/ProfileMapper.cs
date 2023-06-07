using CourseManagement.Models;
using FastEndpoints;

namespace CourseManagement.Endpoints.Creators.Profile
{
    public class ProfileMapper: ResponseMapper<ProfileResponse, Creator>
    {
        public override ProfileResponse FromEntity(Creator e)
        {
            return new ProfileResponse()
            {
                Bio = e.Bio,
                Email = e.Email,
                Username = e.Username,
                Website = e.Website,
            };
        }
    }
}
