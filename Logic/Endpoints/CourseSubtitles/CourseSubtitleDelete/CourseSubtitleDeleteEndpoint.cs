using CourseManagement.Data;
using CourseManagement.Data.Models;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.CourseSubtitles.CourseSubtitleDelete
{
    public class CourseSubtitleDeleteEndpoint : EndpointExtended<CourseSubtitleDeleteRequest>
    {
        public override void Configure()
        {
            ConfigureEndpoint("removeSubtitle");
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
                await SendErrorsAsync(400, ct);
                return;
            }

            courseDbContext.CourseSubtitles.Remove(subtitle);
            courseDbContext.SaveChanges();

            await SendOkAsync(ct);
        }
    }
}
