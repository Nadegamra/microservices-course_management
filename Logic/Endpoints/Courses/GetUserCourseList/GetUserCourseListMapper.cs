using CourseManagement.Data.Models;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.Courses.GetUserCourseList
{
    public class GetUserCourseListMapper : ResponseMapper<GetUserCourseListResponse, Course[]>
    {
        public override GetUserCourseListResponse FromEntity(Course[] e)
        {
            return new GetUserCourseListResponse()
            {
                Items = e.Select(x => new GetUserCourseListItem
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
                    IsHidden = x.IsHidden,
                }).ToArray(),
            };
        }
    }
}
