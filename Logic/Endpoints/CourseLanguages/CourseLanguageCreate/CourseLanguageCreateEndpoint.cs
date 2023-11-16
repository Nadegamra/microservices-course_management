using CourseManagement.Data.Models;
using CourseManagement.Data.Repositories;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.CourseLanguages.CourseLanguageCreate
{
    public class CourseLanguageCreateEndpoint : Endpoint<CourseLanguageCreateRequest, EmptyResponse, CourseLanguageCreateMapper>
    {
        public override void Configure()
        {
            Post("courses/{courseId}/languages");
            Roles("ADMIN", "CREATOR");
        }

        private readonly IRepository<Course> courseRepository;
        private readonly IRepository<CourseLanguage> courseLanguageRepository;

        public CourseLanguageCreateEndpoint(IRepository<Course> courseRepository, IRepository<CourseLanguage> courseLanguageRepository)
        {
            this.courseRepository = courseRepository;
            this.courseLanguageRepository = courseLanguageRepository;
        }

        public override async Task HandleAsync(CourseLanguageCreateRequest req, CancellationToken ct)
        {
            CourseLanguage newLanguage = Map.ToEntity(req);
            Course? course = courseRepository.GetAll().Where(x => x.Id == newLanguage.CourseId && x.UserId == req.UserId).FirstOrDefault();
            if (course == null)
            {
                await SendNotFoundAsync(ct);
                return;
            }
            bool languageAlreadyAdded = courseLanguageRepository.GetAll().Where(x => x.Language == newLanguage.Language && x.CourseId == newLanguage.CourseId).Any();
            if (languageAlreadyAdded)
            {
                await SendErrorsAsync(409, ct);
                return;
            }

            int languagesCount = courseLanguageRepository.GetAll().Where(x => x.CourseId == req.CourseId).ToList().Count();

            newLanguage.IsPrimary = languagesCount == 0;

            courseLanguageRepository.Add(newLanguage);

            await SendNoContentAsync(ct);
        }
    }
}
