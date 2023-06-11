using CourseManagement.Models;
using FastEndpoints;

namespace CourseManagement.Endpoints.CourseRequirements.CourseRequirementCreate
{
    public class CourseRequirementCreateEndpoint: Endpoint<CourseRequirementCreateRequest, EmptyResponse, CourseRequirementCreateMapper>
    {
        public override void Configure()
        {
            Post("courses/{CourseId}/requirements");
        }

        private readonly CourseDbContext courseDbContext;

        public CourseRequirementCreateEndpoint(CourseDbContext courseDbContext)
        {
            this.courseDbContext = courseDbContext;
        }

        public override async Task HandleAsync(CourseRequirementCreateRequest req, CancellationToken ct)
        {
            Course? course = courseDbContext.Courses.Where(x=>x.Id == req.CourseId && x.UserId == req.UserId).FirstOrDefault();
            if(course == null)
            {
                await SendErrorsAsync(400, ct);
                return;
            }

            CourseRequirement requirement = Map.ToEntity(req);
            courseDbContext.CourseRequirements.Add(requirement);
            courseDbContext.SaveChanges();

            await SendOkAsync(ct);
        }
    }
}
