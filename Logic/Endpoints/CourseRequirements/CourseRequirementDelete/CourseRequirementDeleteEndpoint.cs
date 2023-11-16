using CourseManagement.Data.Models;
using CourseManagement.Data.Repositories;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.CourseRequirements.CourseRequirementDelete
{
    public class CourseRequirementDeleteEndpoint : Endpoint<CourseRequirementDeleteRequest>
    {
        public override void Configure()
        {
            Delete("courses/{courseId}/requirements/{id}");
            Roles("ADMIN", "CREATOR");
        }

        private readonly IRepository<Course> courseRepository;
        private readonly IRepository<CourseRequirement> courseRequirementRepository;

        public CourseRequirementDeleteEndpoint(IRepository<Course> courseRepository, IRepository<CourseRequirement> courseRequirementRepository)
        {
            this.courseRepository = courseRepository;
            this.courseRequirementRepository = courseRequirementRepository;
        }

        public override async Task HandleAsync(CourseRequirementDeleteRequest req, CancellationToken ct)
        {
            Course? course = courseRepository.GetAll()
                                .Where(x => x.Id == req.CourseId && x.UserId == req.UserId)
                                .FirstOrDefault();
            CourseRequirement? requirement = courseRequirementRepository.GetAll()
                                                .Where(x => x.Id == req.Id && x.CourseId == req.CourseId)
                                                .FirstOrDefault();
            if (course == null || requirement == null)
            {
                await SendNotFoundAsync(ct);
                return;
            }

            courseRequirementRepository.Delete(requirement);
            await SendNoContentAsync(ct);

        }
    }
}
