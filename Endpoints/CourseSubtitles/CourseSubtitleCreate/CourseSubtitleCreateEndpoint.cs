using CourseManagement.Models;
using FastEndpoints;

namespace CourseManagement.Endpoints.CourseSubtitles.CourseSubtitleCreate
{
    public class CourseSubtitleCreateEndpoint: Endpoint<CourseSubtitleCreateRequest, EmptyResponse, CourseSubtitleCreateMapper>
    {
        public override void Configure()
        {
            Post("courses/{CourseId}/subtitles");
        }

        private readonly CourseDbContext courseDbContext;

        public CourseSubtitleCreateEndpoint(CourseDbContext courseDbContext)
        {
            this.courseDbContext = courseDbContext;
        }

        public override async Task HandleAsync(CourseSubtitleCreateRequest req, CancellationToken ct)
        {
            CourseSubtitle newSubtitle = Map.ToEntity(req);
            Course? course = courseDbContext.Courses.Where(x => x.Id == newSubtitle.CourseId && x.UserId == req.UserId).FirstOrDefault();
            if (course == null || courseDbContext.CourseSubtitles.Where(x => x.Language == newSubtitle.Language && x.CourseId == newSubtitle.CourseId).Any())
            {
                await SendErrorsAsync(418, ct);
                return;
            }

            courseDbContext.CourseSubtitles.Add(newSubtitle);
            courseDbContext.SaveChanges();
            await SendOkAsync(ct);
        }
    }
}
