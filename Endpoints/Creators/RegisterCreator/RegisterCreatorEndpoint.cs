using CourseManagement.Models;
using FastEndpoints;

namespace CourseManagement.Endpoints.Creators.RegisterCreator
{
    public class RegisterCreatorEndpoint: Endpoint<RegisterCreatorRequest, EmptyResponse,RegisterCreatorMapper>
    {
        public override void Configure()
        {
            Post("creator");
            Roles("CREATOR");
        }

        private readonly CourseDbContext courseDbContext;

        public RegisterCreatorEndpoint(CourseDbContext courseDbContext)
        {
            this.courseDbContext = courseDbContext;
        }

        public override async Task HandleAsync(RegisterCreatorRequest req, CancellationToken ct)
        {
            Creator? creator = courseDbContext.Creators.Where(x=>x.Id == req.Id).FirstOrDefault();
            if(creator != null)
            {
                await SendErrorsAsync(418, ct);
                return;
            }

            Creator newCreator = Map.ToEntity(req);
            courseDbContext.Creators.Add(newCreator);
            courseDbContext.SaveChanges();

            await SendOkAsync(ct);
        }
    }
}
