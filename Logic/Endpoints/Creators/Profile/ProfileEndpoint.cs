using CourseManagement.Data.Models;
using CourseManagement.Data.Repositories;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.Creators.Profile
{
    public class ProfileEndpoint : Endpoint<ProfileRequest, ProfileResponse, ProfileMapper>
    {
        public override void Configure()
        {
            Get("creator");
            Roles("ADMIN", "CREATOR");
        }

        private readonly IRepository<Creator> repository;

        public ProfileEndpoint(IRepository<Creator> repository)
        {
            this.repository = repository;
        }

        public override async Task HandleAsync(ProfileRequest req, CancellationToken ct)
        {
            Creator? creator = repository.Get(req.UserId);
            if (creator == null)
            {
                await SendNotFoundAsync(ct);
                return;
            }

            Response = Map.FromEntity(creator);
            await SendOkAsync(Response, ct);
        }
    }
}
