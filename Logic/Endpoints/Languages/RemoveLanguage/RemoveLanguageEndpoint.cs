using CourseManagement.Data.Models;
using CourseManagement.Data.Repositories;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.Languages.RemoveLanguage
{
    public class RemoveLanguageEndpoint : Endpoint<RemoveLanguageRequest>
    {
        public override void Configure()
        {
            Delete("languages/{id}");
            Roles("ADMIN");
        }

        private readonly IRepository<Language> repository;

        public RemoveLanguageEndpoint(IRepository<Language> repository)
        {
            this.repository = repository;
        }

        public override async Task HandleAsync(RemoveLanguageRequest req, CancellationToken ct)
        {
            Language? language = repository.Get(req.Id);
            if (language != null)
            {
                repository.Delete(language);
            }
            await SendOkAsync(ct);
        }
    }
}