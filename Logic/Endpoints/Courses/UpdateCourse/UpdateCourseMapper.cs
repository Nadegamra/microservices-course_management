using CourseManagement.Data.Models;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.Courses.UpdateCourse
{
    public class UpdateCourseMapper : Mapper<UpdateCourseRequest, UpdateCourseResponse, Course>
    {
        public override UpdateCourseResponse FromEntity(Course e)
        {
            return new UpdateCourseResponse()
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

        public override Course UpdateEntity(UpdateCourseRequest r, Course e)
        {
            e.Name = r.Name;
            e.ShortDescription = r.ShortDescription;
            e.DetailedDescription = r.DetailedDescription;
            e.LengthInDays = r.LengthInDays;
            e.Price = r.Price;
            e.GrantsCertificate = r.GrantsCertificate;
            e.CertificatePrice = r.CertificatePrice;
            e.ActivityFormat = r.ActivityFormat;
            e.ScheduleType = r.ScheduleType;
            e.Difficulty = r.Difficulty;
            e.IsHidden = r.IsHidden;
            return e;
        }
    }
}
