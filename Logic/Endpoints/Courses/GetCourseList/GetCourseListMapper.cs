using CourseManagement.Data.Models;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.Courses.GetCourseList
{
    public class GetCourseListMapper : ResponseMapper<GetCourseListResponse, Course[]>
    {
        public override GetCourseListResponse FromEntity(Course[] e)
        {
            return new GetCourseListResponse()
            {
                Items = e.Select(x => new GetCourseListItem
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    Name = x.Name,
                    ShortDescription = x.ShortDescription,
                    DetailedDescription = x.DetailedDescription,
                    LengthInDays = x.LengthInDays,
                    Price = x.Price,
                    GrantsCertificate = x.GrantsCertificate,
                    CertificatePrice = x.CertificatePrice,
                    ActivityFormat = x.ActivityFormat,
                    ScheduleType = x.ScheduleType,
                    Difficulty = x.Difficulty,
                    GainedSkills = x.GainedSkills,
                    Languages = x.Languages,
                    Requirements = x.Requirements,
                    Subtitles = x.Subtitles,
                }).ToArray(),
                Routes = new[] { RoutesConfig.GetRouteDTO("course") }
            };
        }
    }
}
