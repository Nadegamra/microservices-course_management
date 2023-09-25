using CourseManagement.Data;
using CourseManagement.Data.Models;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.CourseLanguages.CourseLanguageGetList
{
    public class CourseLanguageGetListEndpoint : Endpoint<CourseLanguageGetListRequest, List<CourseLanguageGetListResponse>, CourseLanguageGetListMapper>
    {
        public override void Configure()
        {
            Get("courses/{courseId}/languages");
            AllowAnonymous();
        }

        private readonly CourseDbContext courseDbContext;

        public CourseLanguageGetListEndpoint(CourseDbContext courseDbContext)
        {
            this.courseDbContext = courseDbContext;
        }

        public override async Task HandleAsync(CourseLanguageGetListRequest req, CancellationToken ct)
        {
            List<CourseLanguage> courseLanguages = courseDbContext.CourseLanguages.Where(x => x.CourseId == req.CourseId).ToList();
            Response = Map.FromEntity(courseLanguages);
            await SendOkAsync(Response, ct);
        }
    }
}