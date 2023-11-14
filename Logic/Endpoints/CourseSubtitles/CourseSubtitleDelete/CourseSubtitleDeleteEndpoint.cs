using CourseManagement.Data.Models;
using CourseManagement.Data.Repositories;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.CourseSubtitles.CourseSubtitleDelete
{
    public class CourseSubtitleDeleteEndpoint : Endpoint<CourseSubtitleDeleteRequest>
    {
        public override void Configure()
        {
            Delete("courses/{courseId}/subtitles/{id}");
            Roles("ADMIN", "CREATOR");
        }

        private readonly IRepository<Course> courseRepository;
        private readonly IRepository<CourseSubtitle> courseSubtitleRepository;


        public CourseSubtitleDeleteEndpoint(IRepository<Course> courseRepository, IRepository<CourseSubtitle> courseSubtitleRepository)
        {
            this.courseRepository = courseRepository;
            this.courseSubtitleRepository = courseSubtitleRepository;
        }

        public override async Task HandleAsync(CourseSubtitleDeleteRequest req, CancellationToken ct)
        {
            Course? course = courseRepository.GetAll().Where(x => x.Id == req.CourseId && x.UserId == req.UserId).FirstOrDefault();
            CourseSubtitle? subtitle = courseSubtitleRepository.GetAll().Where(x => x.Id == req.Id && x.CourseId == req.CourseId).FirstOrDefault();
            if (course == null || subtitle == null)
            {
                await SendErrorsAsync(400, ct);
                return;
            }

            courseSubtitleRepository.Delete(subtitle);

            await SendOkAsync(ct);
        }
    }
}
