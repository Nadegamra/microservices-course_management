using CourseManagement.Data.Models;
using CourseManagement.Data.Repositories;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.CourseLanguages.CourseLanguageDelete
{
    public class CourseLanguageDeleteEndpoint : Endpoint<CourseLanguageDeleteRequest>
    {
        public override void Configure()
        {
            Delete("courses/{courseId}/languages/{id}");
            Roles("CREATOR");
        }

        private readonly IRepository<Course> courseRepository;
        private readonly IRepository<CourseLanguage> courseLanguageRepository;

        public CourseLanguageDeleteEndpoint(IRepository<Course> courseRepository, IRepository<CourseLanguage> courseLanguageRepository)
        {
            this.courseRepository = courseRepository;
            this.courseLanguageRepository = courseLanguageRepository;
        }

        public override async Task HandleAsync(CourseLanguageDeleteRequest req, CancellationToken ct)
        {
            Course? course = courseRepository.GetAll()
                                .Where(x => x.Id == req.CourseId && x.UserId == req.UserId)
                                .FirstOrDefault();
            CourseLanguage? language = courseLanguageRepository.GetAll()
                                .Where(x => x.Id == req.Id && x.CourseId == req.CourseId)
                                .FirstOrDefault();
            if (course == null || language == null)
            {
                await SendErrorsAsync(400, ct);
                return;
            }

            courseLanguageRepository.Delete(language);

            await SendOkAsync(ct);
        }
    }
}
