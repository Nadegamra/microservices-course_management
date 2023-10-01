using CourseManagement.Data;
using CourseManagement.Data.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Logic.Endpoints.CourseSubtitles.CourseSubtitleGetList
{
    public class CourseSubtitleGetListEndpoint : Endpoint<CourseSubtitleGetListRequest, List<CourseSubtitleGetListResponse>, CourseSubtitleGetListMapper>
    {
        public override void Configure()
        {
            Get("courses/{courseId}/subtitles");
            AllowAnonymous();
        }

        private readonly CourseDbContext courseDbContext;

        public CourseSubtitleGetListEndpoint(CourseDbContext courseDbContext)
        {
            this.courseDbContext = courseDbContext;
        }

        public override async Task HandleAsync(CourseSubtitleGetListRequest req, CancellationToken ct)
        {
            List<CourseSubtitle> courseSubtitles = courseDbContext.CourseSubtitles.Include(x => x.Language).Where(x => x.CourseId == req.CourseId).ToList();
            Response = Map.FromEntity(courseSubtitles);
            await SendOkAsync(Response, ct);
        }
    }
}