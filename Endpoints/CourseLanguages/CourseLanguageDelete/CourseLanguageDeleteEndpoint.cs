using CourseManagement.Models;
using FastEndpoints;

namespace CourseManagement.Endpoints.CourseLanguages.CourseLanguageDelete
{
    public class CourseLanguageDeleteEndpoint : Endpoint<CourseLanguageDeleteRequest>
    {
        public override void Configure()
        {
            Delete("courses/{CourseId}/languages/{Id}");
        }

        private readonly CourseDbContext courseDbContext;

        public CourseLanguageDeleteEndpoint(CourseDbContext courseDbContext)
        {
            this.courseDbContext = courseDbContext;
        }

        public override async Task HandleAsync(CourseLanguageDeleteRequest req, CancellationToken ct)
        {
            Course? course = courseDbContext.Courses.Where(x => x.Id == req.CourseId && x.UserId == req.UserId).FirstOrDefault();
            CourseLanguage? language = courseDbContext.CourseLanguages.Where(x=>x.Id == req.Id && x.CourseId == req.CourseId).FirstOrDefault();
            if (course == null || language == null)
            {
                await SendErrorsAsync(400, ct);
                return;
            }

            courseDbContext.CourseLanguages.Remove(language);
            courseDbContext.SaveChanges();

            await SendOkAsync(ct);
        }
    }
}
