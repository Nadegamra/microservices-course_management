using CourseManagement.Models;
using FastEndpoints;

namespace CourseManagement.Endpoints.Creators.Profile
{
    public class ProfileEndpoint: Endpoint<ProfileRequest, ProfileResponse, ProfileMapper>
    {
        public override void Configure()
        {
            Get("creator");
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
                await SendErrorsAsync(418, ct);
                return;
            }

            Response = Map.FromEntity(creator);
            await SendOkAsync(Response, ct);
        }
    }
}
