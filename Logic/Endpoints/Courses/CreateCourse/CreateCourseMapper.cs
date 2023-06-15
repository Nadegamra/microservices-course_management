using CourseManagement.Data.Models;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.Courses.CreateCourse
{
    public class CreateCourseMapper : Mapper<CreateCourseRequest, CreateCourseResponse, Course>
    {
        public override CreateCourseResponse FromEntity(Course e)
        {
            return new CreateCourseResponse
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
                IsHidden = e.IsHidden,
            };
        }

        public override Course ToEntity(CreateCourseRequest r)
        {
            return new Course
            {
                UserId = r.UserId,
                ImageId = "",
                Name = r.Name,
                ShortDescription = r.ShortDescription,
                DetailedDescription = r.DetailedDescription,
                LengthInDays = r.LengthInDays,
                Price = r.Price,
                GrantsCertificate = r.GrantsCertificate,
                CertificatePrice = r.CertificatePrice,
                ActivityFormat = r.ActivityFormat,
                ScheduleType = r.ScheduleType,
                Difficulty = r.Difficulty,
                IsDeleted = false,
                IsHidden = false,
            };
        }
    }
}
