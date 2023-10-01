using CourseManagement.Data;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.Languages.GetLanguageList
{
    public class GetLanguageListEndpoint : Endpoint<EmptyRequest, List<GetLanguageListResponse>, GetLanguageListMapper>
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

        public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
        {
            List<Data.Models.Language> languages = courseDbContext.Languages.ToList();
            Response = Map.FromEntity(languages);
            await SendOkAsync(Response, ct);
        }
    }
}