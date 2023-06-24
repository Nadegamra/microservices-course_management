using CourseManagement.Data;
using CourseManagement.Data.Models;
using FastEndpoints;
using Infrastructure.Routes;

namespace CourseManagement.Logic.Endpoints.Creators.RegisterCreator
{
    public class RegisterCreatorEndpoint : EndpointExtended<RegisterCreatorRequest, EmptyResponse, RegisterCreatorMapper>
    {
        public override void Configure()
        {
            ConfigureEndpoint("registerCreator");
        }

        private readonly CourseDbContext courseDbContext;

        public RegisterCreatorEndpoint(CourseDbContext courseDbContext)
        {
            this.courseDbContext = courseDbContext;
        }

        public override async Task HandleAsync(RegisterCreatorRequest req, CancellationToken ct)
        {
            Creator? creator = courseDbContext.Creators.Where(x => x.Id == req.Id).FirstOrDefault();
            if (creator != null)
            {
                await SendErrorsAsync(400, ct);
                return;
            }

            Creator newCreator = Map.ToEntity(req);
            courseDbContext.Creators.Add(newCreator);
            courseDbContext.SaveChanges();

            await SendOkAsync(ct);
        }
    }
}
