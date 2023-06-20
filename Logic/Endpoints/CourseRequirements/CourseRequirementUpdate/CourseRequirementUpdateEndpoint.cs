using CourseManagement.Data;
using CourseManagement.Data.Models;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.CourseRequirements.CourseRequirementUpdate
{
    public class CourseRequirementUpdateEndpoint : EndpointExtended<CourseRequirementUpdateRequest, EmptyResponse, CourseRequirementUpdateMapper>
    {
        public override void Configure()
        {
            ConfigureEndpoint("updateRequirement");
        }

        private readonly CourseDbContext courseDbContext;

        public CourseRequirementUpdateEndpoint(CourseDbContext courseDbContext)
        {
            this.courseDbContext = courseDbContext;
        }

        public override async Task HandleAsync(CourseRequirementUpdateRequest req, CancellationToken ct)
        {
            Course? course = courseDbContext.Courses.Where(x => x.Id == req.CourseId && x.UserId == req.UserId).FirstOrDefault();
            CourseRequirement? requirement = courseDbContext.CourseRequirements.Where(x => x.Id == req.Id && x.CourseId == req.CourseId).FirstOrDefault();

            if (course == null || requirement == null || requirement.SkillId != null)
            {
                await SendErrorsAsync(400, ct);
                return;
            }

            requirement = Map.UpdateEntity(req, requirement);
            courseDbContext.CourseRequirements.Update(requirement);
            courseDbContext.SaveChanges();

            await SendOkAsync(ct);
        }
    }
}
