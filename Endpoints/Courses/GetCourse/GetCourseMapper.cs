using CourseManagement.Models;
using FastEndpoints;

namespace CourseManagement.Endpoints.Courses.GetCourse
{
    public class GetCourseMapper : ResponseMapper<GetCourseResponse, Course>
    {
        public override GetCourseResponse FromEntity(Course e)
        {
            return new GetCourseResponse
            {
                Id = e.Id,
                UserId = e.UserId,
                Name = e.Name,
                ShortDescription = e.ShortDescription,
                DetailedDescription = e.DetailedDescription,
                LengthInDays = e.LengthInDays,
                Price = e.Price,
                GrantsCertificate = e.GrantsCertificate,
                CertificatePrice = e.CertificatePrice,
                ActivityFormat = e.ActivityFormat,
                ScheduleType = e.ScheduleType,
                Difficulty = e.Difficulty,
                GainedSkills = e.GainedSkills,
                Languages = e.Languages,
                Requirements = e.Requirements,
                Subtitles = e.Subtitles,
            };
        }
    }
}
