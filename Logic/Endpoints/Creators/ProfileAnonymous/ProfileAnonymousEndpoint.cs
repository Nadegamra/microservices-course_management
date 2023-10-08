using CourseManagement.Data;
using CourseManagement.Data.Models;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.Creators.ProfileAnonymous
{
    public class ProfileAnonymousEndpoint : Endpoint<ProfileAnonymousRequest, ProfileAnonymousResponse, ProfileAnonymousMapper>
    {
        public override void Configure()
        {
            Get("creator/{UserId}");
            AllowAnonymous();
        }

        private readonly CourseDbContext courseDbContext;

        public ProfileAnonymousEndpoint(CourseDbContext courseDbContext)
        {
            this.courseDbContext = courseDbContext;
        }

        public async override Task HandleAsync(ProfileAnonymousRequest req, CancellationToken ct)
        {
            Creator? creator = courseDbContext.Creators.Where(x => x.Id == req.UserId).FirstOrDefault();
            if (creator == null)
            {
                await SendErrorsAsync(400, ct);
                return;
            }

            Response = Map.FromEntity(creator);
            await SendOkAsync(Response, ct);
        }
    }
}