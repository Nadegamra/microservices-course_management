using CourseManagement.Data.Models;
using CourseManagement.Data.Repositories;
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

        private readonly IRepository<Creator> repository;

        public ProfileAnonymousEndpoint(IRepository<Creator> repository)
        {
            this.repository = repository;
        }

        public async override Task HandleAsync(ProfileAnonymousRequest req, CancellationToken ct)
        {
            Creator? creator = repository.Get(req.UserId);
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