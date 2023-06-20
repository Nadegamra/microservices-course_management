using CourseManagement.Data;
using CourseManagement.Data.Models;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.Creators.Profile
{
    public class ProfileEndpoint: EndpointExtended<ProfileRequest, ProfileResponse, ProfileMapper>
    {
        public override void Configure()
        {
            ConfigureEndpoint("profile");
        }

        private readonly CourseDbContext courseDbContext;

        public ProfileEndpoint(CourseDbContext courseDbContext)
        {
            this.courseDbContext = courseDbContext;
        }

        public override async Task HandleAsync(ProfileRequest req, CancellationToken ct)
        {
            Creator? creator = courseDbContext.Creators.Where(x=>x.Id == req.UserId).FirstOrDefault();
            if(creator == null)
            {
                await SendErrorsAsync(400, ct);
                return;
            }

            Response = Map.FromEntity(creator);
            await SendOkAsync(Response, ct);
        }
    }
}
