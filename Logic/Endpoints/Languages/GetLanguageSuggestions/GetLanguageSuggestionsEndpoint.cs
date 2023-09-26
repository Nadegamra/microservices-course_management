using System.Text.RegularExpressions;
using CourseManagement.Data;
using CourseManagement.Data.Models;
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

        private readonly CourseDbContext courseDbContext;

        public GetLanguageSuggestionsEndpoint(CourseDbContext courseDbContext)
        {
            this.courseDbContext = courseDbContext;
        }

        public override async Task HandleAsync(GetLanguageSuggestionsRequest req, CancellationToken ct)
        {
            if (req.Name == "")
            {
                await SendOkAsync(ct);
                return;
            }
            List<Language> languages = courseDbContext.Languages.Where(x => Regex.IsMatch(x.Name.ToLower(), $@"^.*({Regex.Escape(req.Name.ToLower())}).*$")).Take(5).ToList();
            Response = Map.FromEntity(languages);
            await SendOkAsync(Response, ct);
        }
    }
}