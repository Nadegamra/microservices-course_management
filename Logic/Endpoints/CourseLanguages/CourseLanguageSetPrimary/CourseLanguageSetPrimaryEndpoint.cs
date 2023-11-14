using CourseManagement.Data.Models;
using CourseManagement.Data.Repositories;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.CourseLanguages.CourseLanguageSetPrimary
{
    public class CourseLanguageSetPrimaryEndpoint : Endpoint<CourseLanguageSetPrimaryRequest>
    {
        public override void Configure()
        {
            Put("courses/{courseId}/languages/{id}");
            Roles("ADMIN", "CREATOR");
        }

        private readonly IRepository<CourseLanguage> repository;

        public CourseLanguageSetPrimaryEndpoint(IRepository<CourseLanguage> repository)
        {
            this.repository = repository;
        }

        public override async Task HandleAsync(CourseLanguageSetPrimaryRequest req, CancellationToken ct)
        {
            List<CourseLanguage> languages = repository.GetAll().Where(x => x.CourseId == req.CourseId).ToList();
            foreach (var language in languages)
            {
                if (language.Id != req.Id)
                {
                    language.IsPrimary = false;
                }
                else
                {
                    language.IsPrimary = true;
                }
                repository.Update(language);
            }
            await SendOkAsync(ct);
        }
    }
}