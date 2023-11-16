using CourseManagement.Data.Models;
using CourseManagement.Data.Repositories;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.Languages.AddLanguage
{
    public class AddLanguageEndpoint : Endpoint<AddLanguageRequest, EmptyResponse, AddLanguageMapper>
    {
        public override void Configure()
        {
            Post("languages");
            Roles("ADMIN");
        }

        private readonly IRepository<Language> repository;

        public AddLanguageEndpoint(IRepository<Language> repository)
        {
            this.repository = repository;
        }

        public override async Task HandleAsync(AddLanguageRequest req, CancellationToken ct)
        {
            List<Language> languages = repository.GetAll().Where(x => x.Name.ToUpper() == req.Name.ToUpper()).ToList();// language already exists
            if (languages.Count > 0)
            {
                await SendErrorsAsync(409, ct);
                return;
            }

            Language newLanguage = Map.ToEntity(req);
            repository.Add(newLanguage);

            await SendNoContentAsync(ct);
        }
    }
}