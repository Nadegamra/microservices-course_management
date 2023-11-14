using CourseManagement.Data.Models;
using CourseManagement.Data.Repositories;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.Languages.GetLanguageCount
{
    public class GetLanguageListEndpoint : Endpoint<EmptyRequest, GetLanguageCountResponse>
    {
        public override void Configure()
        {
            Get("languages/count");
            AllowAnonymous();
        }

        private readonly IRepository<Language> repository;

        public GetLanguageListEndpoint(IRepository<Language> repository)
        {
            this.repository = repository;
        }

        public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
        {
            int count = repository.GetAll().Count();
            Response = new GetLanguageCountResponse { Count = count };
            await SendOkAsync(Response, ct);
        }
    }
}