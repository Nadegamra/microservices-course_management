using CourseManagement.Data.Models;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.Creators.ProfileAnonymous
{
    public class ProfileAnonymousMapper : ResponseMapper<ProfileAnonymousResponse, Creator>
    {
        public override ProfileAnonymousResponse FromEntity(Creator e)
        {
            return new ProfileAnonymousResponse()
            {
                Bio = e.Bio,
                Email = e.Email,
                Username = e.Username,
                Website = e.Website,
            };
        }
    }
}