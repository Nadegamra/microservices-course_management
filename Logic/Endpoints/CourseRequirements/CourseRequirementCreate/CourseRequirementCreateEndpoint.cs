using CourseManagement.Data.Models;
using CourseManagement.Data.Repositories;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.CourseRequirements.CourseRequirementCreate
{
    public class CourseRequirementCreateEndpoint : Endpoint<CourseRequirementCreateRequest, EmptyResponse, CourseRequirementCreateMapper>
    {
        public override void Configure()
        {
            Post("courses/{courseId}/requirements");
            Roles("ADMIN", "CREATOR");
        }

        private readonly IRepository<Course> courseRepository;
        private readonly IRepository<CourseRequirement> courseRequirementRepository;

        public CourseRequirementCreateEndpoint(IRepository<Course> courseRepository, IRepository<CourseRequirement> courseRequirementRepository)
        {
            this.courseRepository = courseRepository;
            this.courseRequirementRepository = courseRequirementRepository;
        }

        public override async Task HandleAsync(CourseRequirementCreateRequest req, CancellationToken ct)
        {
            Course? course = courseRepository.GetAll()
                                .Where(x => x.Id == req.CourseId && x.UserId == req.UserId)
                                .FirstOrDefault();
            bool badRequest = req.SkillId != null && req.CustomDescription != null && req.CustomDescription != "";
            if (course == null || badRequest)
            {
                await SendErrorsAsync(400, ct);
                return;
            }
            bool courseAlreadyHasSkill = courseRequirementRepository.GetAll()
                                        .Where(x => x.SkillId == req.SkillId && x.CourseId == req.CourseId).Any();
            if (req.SkillId != null && courseAlreadyHasSkill)
            {
                await SendErrorsAsync(409, ct);
                return;
            }

            CourseRequirement requirement = Map.ToEntity(req);
            courseRequirementRepository.Add(requirement);

            await SendNoContentAsync(ct);
        }
    }
}
