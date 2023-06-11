using CourseManagement.Models;
using FastEndpoints;

namespace CourseManagement.Endpoints.CourseSubtitles.CourseSubtitleDelete
{
    public class CourseSubtitleDeleteEndpoint: Endpoint<CourseSubtitleDeleteRequest>
    {
        public override void Configure()
        {
            Delete("courses/{CourseId}/subtitles");
        }

        private readonly CourseDbContext courseDbContext;

        public CourseSubtitleDeleteEndpoint(CourseDbContext courseDbContext)
        {
            this.courseDbContext = courseDbContext;
        }

        public override async Task HandleAsync(CourseSubtitleDeleteRequest req, CancellationToken ct)
        {
            Course? course = courseDbContext.Courses.Where(x => x.Id == req.CourseId && x.UserId == req.UserId).FirstOrDefault();
            CourseSubtitle? subtitle = courseDbContext.CourseSubtitles.Where(x => x.Id == req.Id && x.CourseId == req.CourseId).FirstOrDefault();
            if (course == null || subtitle == null)
            {
                await SendErrorsAsync(418, ct);
                return;
            }

            courseDbContext.CourseSubtitles.Remove(subtitle);
            courseDbContext.SaveChanges();

            await SendOkAsync(ct);
        }
    }
}
