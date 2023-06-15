using CourseManagement.Data;
using CourseManagement.Data.Models;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.CourseRequirements.CourseRequirementDelete
{
    public class CourseRequirementDeleteEndpoint: EndpointExtended<CourseRequirementDeleteRequest>
    {
        public override void Configure()
        {
            ConfigureEndpoint("removeRequirement");
        }

        private readonly CourseDbContext courseDbContext;

        public CourseRequirementDeleteEndpoint(CourseDbContext courseDbContext)
        {
            this.courseDbContext = courseDbContext;
        }

        public override async Task HandleAsync(CourseRequirementDeleteRequest req, CancellationToken ct)
        {
            Course? course = courseDbContext.Courses.Where(x=>x.Id == req.CourseId && x.UserId == req.UserId).FirstOrDefault();
            CourseRequirement? requirement = courseDbContext.CourseRequirements.Where(x=>x.Id == req.Id && x.CourseId == req.CourseId).FirstOrDefault();
            if(course == null || requirement == null)
            {
                await SendErrorsAsync(400, ct);
                return;
            }

            courseDbContext.CourseRequirements.Remove(requirement);
            courseDbContext.SaveChanges();
            await SendOkAsync(ct);

        }
    }
}
