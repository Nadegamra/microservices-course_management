using CourseManagement.Data;
using CourseManagement.Data.Models;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.Courses.UpdateCourse
{
    public class UpdateCourseEndpoint : EndpointExtended<UpdateCourseRequest, UpdateCourseResponse, UpdateCourseMapper>
    {
        public override void Configure()
        {
            ConfigureEndpoint("updateCourse");
        }

        private readonly CourseDbContext courseDbContext;

        public UpdateCourseEndpoint(CourseDbContext courseDbContext)
        {
            this.courseDbContext = courseDbContext;
        }

        public override async Task HandleAsync(UpdateCourseRequest req, CancellationToken ct)
        {
            Course? original = courseDbContext.Courses.Where(x => x.Id == req.Id && x.UserId == req.UserId).FirstOrDefault();
            if (original == null)
            {
                await SendErrorsAsync(418, ct);
                return;
            }

            Course updated = Map.UpdateEntity(req, original);
            var res = courseDbContext.Courses.Update(updated);
            courseDbContext.SaveChanges();

            Response = Map.FromEntity(res.Entity);
            await SendOkAsync(Response, ct);
        }
    }
}
