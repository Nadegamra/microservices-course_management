using CourseManagement.Data.Models;
using CourseManagement.Data.Repositories;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.Languages.GetLanguageList
{
    public class GetLanguageListEndpoint : Endpoint<GetLanguageListRequest, List<GetLanguageListResponse>, GetLanguageListMapper>
    {
        public override void Configure()
        {
            Get("languages");
            AllowAnonymous();
        }

        private readonly IRepository<Language> repository;

        public GetLanguageListEndpoint(IRepository<Language> repository)
        {
            this.repository = repository;
        }

        public override async Task HandleAsync(GetLanguageListRequest req, CancellationToken ct)
        {
            List<Language> languages = repository.GetAll().Skip(req.Skip).Take(req.Take).ToList();
            Response = Map.FromEntity(languages);
            await SendOkAsync(Response, ct);
        }
    }
}