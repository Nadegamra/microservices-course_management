using CourseManagement.Data.Models;
using CourseManagement.Data.Repositories;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.CourseRequirements.CourseRequirementUpdate
{
    public class CourseRequirementUpdateEndpoint : Endpoint<CourseRequirementUpdateRequest, EmptyResponse, CourseRequirementUpdateMapper>
    {
        public override void Configure()
        {
            Put("courses/{courseId}/requirements/{id}");
            Roles("ADMIN", "CREATOR");
        }

        private readonly IRepository<Course> courseRepository;
        private readonly IRepository<CourseRequirement> courseRequirementRepository;

        public CourseRequirementUpdateEndpoint(IRepository<Course> courseRepository, IRepository<CourseRequirement> courseRequirementRepository)
        {
            this.courseRepository = courseRepository;
            this.courseRequirementRepository = courseRequirementRepository;
        }

        public override async Task HandleAsync(CourseRequirementUpdateRequest req, CancellationToken ct)
        {
            Course? course = courseRepository.GetAll()
                                .Where(x => x.Id == req.CourseId && x.UserId == req.UserId)
                                .FirstOrDefault();
            CourseRequirement? requirement = courseRequirementRepository.GetAll()
                                            .Where(x => x.Id == req.Id && x.CourseId == req.CourseId)
                                            .FirstOrDefault();

            if (course == null || requirement == null || requirement.SkillId != null)
            {
                await SendNotFoundAsync(ct);
                return;
            }

            requirement = Map.UpdateEntity(req, requirement);
            courseRequirementRepository.Update(requirement);

            await SendNoContentAsync(ct);
        }
    }
}
