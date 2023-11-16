using CourseManagement.Data.Models;
using CourseManagement.Data.Repositories;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.Creators.UpdateCreator
{
    public class UpdateCreatorEndpoint : Endpoint<UpdateCreatorRequest, EmptyResponse, UpdateCreatorMapper>
    {
        public override void Configure()
        {
            Put("creator");
            Roles("CREATOR");
        }

        private readonly IRepository<Creator> repository;

        public UpdateCreatorEndpoint(IRepository<Creator> repository)
        {
            this.repository = repository;
        }

        public override async Task HandleAsync(UpdateCreatorRequest req, CancellationToken ct)
        {
            Creator? original = repository.Get(req.UserId);
            if (original == null)
            {
                await SendErrorsAsync(400, ct);
                return;
            }

            Creator updated = Map.UpdateEntity(req, original);
            repository.Update(updated);

            await SendOkAsync(ct);
        }
    }
}
