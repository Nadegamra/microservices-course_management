using CourseManagement.Data;
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

        private readonly CourseDbContext courseDbContext;

        public GetLanguageListEndpoint(CourseDbContext courseDbContext)
        {
            this.courseDbContext = courseDbContext;
        }

        public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
        {
            int count = courseDbContext.Languages.Count();
            Response = new GetLanguageCountResponse { Count = count };
            await SendOkAsync(Response, ct);
        }
    }
}