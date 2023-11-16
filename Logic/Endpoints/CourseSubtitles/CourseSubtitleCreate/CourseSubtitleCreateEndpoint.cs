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
            Roles("ADMIN", "CREATOR");
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
            var alreadyExists = courseSubtitleRepository.GetAll().Where(x => x.Language == newSubtitle.Language && x.CourseId == newSubtitle.CourseId).Any();
            if (course == null || alreadyExists)
            {
                await SendErrorsAsync(409, ct);
                return;
            }

            courseSubtitleRepository.Add(newSubtitle);

            await SendNoContentAsync(ct);
        }
    }
}
