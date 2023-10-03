using CourseManagement.Data;
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

        private readonly CourseDbContext courseDbContext;

        public GetLanguageListEndpoint(CourseDbContext courseDbContext)
        {
            this.courseDbContext = courseDbContext;
        }

        public override async Task HandleAsync(GetLanguageListRequest req, CancellationToken ct)
        {
            List<Data.Models.Language> languages = courseDbContext.Languages.Skip(req.Skip).Take(req.Take).ToList();
            Response = Map.FromEntity(languages);
            await SendOkAsync(Response, ct);
        }
    }
}