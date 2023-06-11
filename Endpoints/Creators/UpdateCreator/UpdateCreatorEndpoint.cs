using CourseManagement.Models;
using FastEndpoints;

namespace CourseManagement.Endpoints.Creators.UpdateCreator
{
    public class UpdateCreatorEndpoint: Endpoint<UpdateCreatorRequest, EmptyResponse, UpdateCreatorMapper>
    {
        public override void Configure()
        {
            Put("creator");
            Roles("CREATOR");
        }

        private readonly CourseDbContext courseDbContext;

        public UpdateCreatorEndpoint(CourseDbContext courseDbContext)
        {
            this.courseDbContext = courseDbContext;
        }

        public override async Task HandleAsync(UpdateCreatorRequest req, CancellationToken ct)
        {
            Creator? original = courseDbContext.Creators.Where(x=>x.Id == req.UserId).FirstOrDefault();
            if(original == null) {
                await SendErrorsAsync(400, ct);
                return;
            }

            Creator updated = Map.UpdateEntity(req, original);
            courseDbContext.Creators.Update(updated);
            courseDbContext.SaveChanges();

            await SendOkAsync(ct);
        }
    }
}
