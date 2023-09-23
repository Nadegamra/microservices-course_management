using System.Text.RegularExpressions;
using CourseManagement.Data;
using CourseManagement.Data.Models;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.Skills.GetSkillSuggestions
{

    public class GetSkillSuggestionsEndpoint : Endpoint<GetSkillSuggestionsRequest, List<GetSkillSuggestionsResponse>, GetSkillSuggestionsMapper>
    {
        public override void Configure()
        {
            Get("skills/suggestions");
            AllowAnonymous();
        }

        private readonly CourseDbContext courseDbContext;

        public GetSkillSuggestionsEndpoint(CourseDbContext courseDbContext)
        {
            this.courseDbContext = courseDbContext;
        }

        public override async Task HandleAsync(GetSkillSuggestionsRequest req, CancellationToken ct)
        {
            if (req.Name == "")
            {
                await SendOkAsync(ct);
                return;
            }
            List<Skill> skills = courseDbContext.Skills.Where(x => Regex.IsMatch(x.Name.ToLower(), $@"^.*({Regex.Escape(req.Name.ToLower())}).*$")).Take(5).ToList();
            Response = Map.FromEntity(skills);
            await SendOkAsync(Response, ct);
        }
    }
}