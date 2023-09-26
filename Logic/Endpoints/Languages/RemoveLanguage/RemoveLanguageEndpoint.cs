using CourseManagement.Data;
using CourseManagement.Data.Models;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.Languages.RemoveLanguage
{
    public class RemoveLanguageEndpoint : Endpoint<RemoveLanguageRequest>
    {
        public override void Configure()
        {
            Delete("languages/{id}");
            Roles("ADMIN");
        }

        private readonly CourseDbContext courseDbContext;

        public RemoveLanguageEndpoint(CourseDbContext courseDbContext)
        {
            this.courseDbContext = courseDbContext;
        }

        public override async Task HandleAsync(RemoveLanguageRequest req, CancellationToken ct)
        {
            Language? language = courseDbContext.Languages.Where(x => x.Id == req.Id).FirstOrDefault();
            if (language != null)
            {
                courseDbContext.Languages.Remove(language);
                courseDbContext.SaveChanges();
            }
            await SendOkAsync(ct);
        }
    }
}