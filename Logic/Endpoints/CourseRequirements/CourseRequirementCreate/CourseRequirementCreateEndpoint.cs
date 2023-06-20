using CourseManagement.Data;
using CourseManagement.Data.Models;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.CourseRequirements.CourseRequirementCreate
{
    public class CourseRequirementCreateEndpoint: EndpointExtended<CourseRequirementCreateRequest, EmptyResponse, CourseRequirementCreateMapper>
    {
        public override void Configure()
        {
            ConfigureEndpoint("addRequirement");
        }

        private readonly CourseDbContext courseDbContext;

        public CourseRequirementCreateEndpoint(CourseDbContext courseDbContext)
        {
            this.courseDbContext = courseDbContext;
        }

        public override async Task HandleAsync(CourseRequirementCreateRequest req, CancellationToken ct)
        {
            Course? course = courseDbContext.Courses.Where(x=>x.Id == req.CourseId && x.UserId == req.UserId).FirstOrDefault();
            if(course == null || (req.SkillId != null && req.CustomDescription != null))
            {
                await SendErrorsAsync(400, ct);
                return;
            }
            if (req.SkillId != null && courseDbContext.CourseRequirements.Where(x=> x.SkillId == req.SkillId && x.CourseId == req.CourseId).Any())
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
