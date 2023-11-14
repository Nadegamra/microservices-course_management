using System.Text.RegularExpressions;
using CourseManagement.Data.Models;
using CourseManagement.Data.Repositories;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.Languages.GetLanguageSuggestions
{
    public class GetLanguageSuggestionsEndpoint : Endpoint<GetLanguageSuggestionsRequest, List<GetLanguageSuggestionsResponse>, GetLanguageSuggestionsMapper>
    {
        public override void Configure()
        {
            Get("languages/suggestions");
            AllowAnonymous();
        }

        private readonly IRepository<Language> repository;

        public GetLanguageSuggestionsEndpoint(IRepository<Language> repository)
        {
            this.repository = repository;
        }

        public override async Task HandleAsync(GetLanguageSuggestionsRequest req, CancellationToken ct)
        {
            if (req.Name == "")
            {
                await SendOkAsync(ct);
                return;
            }
            List<Language> languages = repository.GetAll().Where(x => Regex.IsMatch(x.Name.ToLower(), $@"^.*({Regex.Escape(req.Name.ToLower())}).*$")).Take(5).ToList();
            Response = Map.FromEntity(languages);
            await SendOkAsync(Response, ct);
        }
    }
}