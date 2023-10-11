using CourseManagement.Data;
using CourseManagement.Data.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Logic.Endpoints.Courses.GetCourse
{
    public class GetCourseEndpoint : Endpoint<GetCourseRequest, GetCourseResponse, GetCourseMapper>
    {
        public override void Configure()
        {
            Get("courses/{id}");
            AllowAnonymous();
        }

        private readonly CourseDbContext courseDbContext;

        public GetCourseEndpoint(CourseDbContext courseDbContext)
        {
            this.courseDbContext = courseDbContext;
        }

        public override async Task HandleAsync(GetCourseRequest req, CancellationToken ct)
        {
            int userId = -1;
            Course? course;
            try
            {
                userId = Convert.ToInt32(User.Claims.Where(x => x.Type == "UserId").First().Value);
                course = courseDbContext.Courses.Include(x => x.Requirements).ThenInclude(x => x.Skill).Include(x => x.GainedSkills).ThenInclude(x => x.Skill).Include(x => x.Languages).ThenInclude(x => x.Language).Include(x => x.Subtitles).ThenInclude(x => x.Language).Where(x => x.Id == req.Id && x.UserId == userId && !x.IsDeleted).FirstOrDefault();
            }
            catch
            {
                course = courseDbContext.Courses.Include(x => x.Requirements).ThenInclude(x => x.Skill).Include(x => x.GainedSkills).ThenInclude(x => x.Skill).Include(x => x.Languages).ThenInclude(x => x.Language).Include(x => x.Subtitles).ThenInclude(x => x.Language).Where(x => x.Id == req.Id && !x.IsHidden && !x.IsDeleted).FirstOrDefault();
            }

            if (course == null)
            {
                await SendNotFoundAsync(ct);
                return;
            }
            Response = Map.FromEntity(course);
            await SendOkAsync(Response, ct);
        }
    }
}
