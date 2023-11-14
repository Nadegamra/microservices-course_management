using System.Text.RegularExpressions;
using CourseManagement.Data.Models;
using CourseManagement.Data.Repositories;
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

        private readonly IRepository<Skill> repository;

        public GetSkillSuggestionsEndpoint(IRepository<Skill> repository)
        {
            this.repository = repository;
        }

        public override async Task HandleAsync(GetSkillSuggestionsRequest req, CancellationToken ct)
        {
            if (req.Name == "")
            {
                await SendOkAsync(ct);
                return;
            }
            List<Skill> skills = repository.GetAll().Where(x => Regex.IsMatch(x.Name.ToLower(), $@"^.*({Regex.Escape(req.Name.ToLower())}).*$")).Take(5).ToList();
            Response = Map.FromEntity(skills);
            await SendOkAsync(Response, ct);
        }
    }
}