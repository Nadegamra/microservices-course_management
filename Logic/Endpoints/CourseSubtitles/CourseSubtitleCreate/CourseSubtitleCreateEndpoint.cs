using CourseManagement.Data;
using CourseManagement.Data.Models;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.CourseSubtitles.CourseSubtitleCreate
{
    public class CourseSubtitleCreateEndpoint : EndpointExtended<CourseSubtitleCreateRequest, EmptyResponse, CourseSubtitleCreateMapper>
    {
        public override void Configure()
        {
            ConfigureEndpoint("addSubtitle");
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
                await SendErrorsAsync(400, ct);
                return;
            }

            courseDbContext.CourseSubtitles.Add(newSubtitle);
            courseDbContext.SaveChanges();
            await SendOkAsync(ct);
        }
    }
}
