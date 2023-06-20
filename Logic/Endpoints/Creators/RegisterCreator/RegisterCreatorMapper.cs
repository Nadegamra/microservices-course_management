using CourseManagement.Data.Models;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.Creators.RegisterCreator
{
    public class RegisterCreatorMapper: RequestMapper<RegisterCreatorRequest, Creator>
    {
        public override Creator ToEntity(RegisterCreatorRequest r)
        {
            return new Creator()
            {
                Id = r.Id,
                Email = r.Email,
                NormalizedEmail = r.Email.ToUpper(),
                Username = r.Username,
                NormalizedUsername = r.Username.ToUpper(),
                Bio = r.Bio,
                Website = r.Website,
            };
        }
    }
}
