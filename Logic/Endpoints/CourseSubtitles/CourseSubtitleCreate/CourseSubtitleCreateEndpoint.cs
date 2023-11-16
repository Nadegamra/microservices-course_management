using CourseManagement.Data.Models;
using CourseManagement.Data.Repositories;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.CourseSubtitles.CourseSubtitleCreate
{
    public class CourseSubtitleCreateEndpoint : Endpoint<CourseSubtitleCreateRequest, EmptyResponse, CourseSubtitleCreateMapper>
    {
        public override void Configure()
        {
            Post("courses/{courseId}/subtitles");
            Roles("CREATOR");
        }

        private readonly IRepository<Course> courseRepository;
        private readonly IRepository<CourseSubtitle> courseSubtitleRepository;

        public CourseSubtitleCreateEndpoint(IRepository<Course> courseRepository, IRepository<CourseSubtitle> courseSubtitleRepository)
        {
            this.courseRepository = courseRepository;
            this.courseSubtitleRepository = courseSubtitleRepository;
        }

        public override async Task HandleAsync(CourseSubtitleCreateRequest req, CancellationToken ct)
        {
            CourseSubtitle newSubtitle = Map.ToEntity(req);
            Course? course = courseRepository.GetAll()
                            .Where(x => x.Id == newSubtitle.CourseId && x.UserId == req.UserId)
                            .FirstOrDefault();
            if (course == null || courseSubtitleRepository.GetAll().Where(x => x.Language == newSubtitle.Language && x.CourseId == newSubtitle.CourseId).Any())
            {
                await SendErrorsAsync(400, ct);
                return;
            }

            courseSubtitleRepository.Add(newSubtitle);

            await SendOkAsync(ct);
        }
    }
}
