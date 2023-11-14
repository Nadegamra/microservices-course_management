using CourseManagement.Data.Models;
using CourseManagement.Data.Repositories;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.CourseSubtitles.CourseSubtitleGetList
{
    public class CourseSubtitleGetListEndpoint : Endpoint<CourseSubtitleGetListRequest, List<CourseSubtitleGetListResponse>, CourseSubtitleGetListMapper>
    {
        public override void Configure()
        {
            Get("courses/{courseId}/subtitles");
            AllowAnonymous();
        }

        private readonly IRepository<Course> courseRepository;
        private readonly IRepository<CourseSubtitle> courseSubtitleRepository;

        public CourseSubtitleGetListEndpoint(IRepository<Course> courseRepository, IRepository<CourseSubtitle> courseSubtitleRepository)
        {
            this.courseRepository = courseRepository;
            this.courseSubtitleRepository = courseSubtitleRepository;
        }

        public override async Task HandleAsync(CourseSubtitleGetListRequest req, CancellationToken ct)
        {
            List<CourseSubtitle> courseSubtitles = courseSubtitleRepository.GetAll().Where(x => x.CourseId == req.CourseId).ToList();
            Response = Map.FromEntity(courseSubtitles);
            await SendOkAsync(Response, ct);
        }
    }
}