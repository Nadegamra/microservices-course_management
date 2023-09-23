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
            e.Name = r.Name ?? e.Name;
            e.ShortDescription = r.ShortDescription ?? e.ShortDescription;
            e.DetailedDescription = r.DetailedDescription ?? e.DetailedDescription;
            e.LengthInDays = r.LengthInDays ?? e.LengthInDays;
            e.Price = r.Price ?? e.Price;
            e.GrantsCertificate = r.GrantsCertificate ?? e.GrantsCertificate;
            e.CertificatePrice = r.CertificatePrice ?? e.CertificatePrice;
            if (!e.GrantsCertificate)
            {
                e.CertificatePrice = 0;
            }
            e.ActivityFormat = r.ActivityFormat ?? e.ActivityFormat;
            e.ScheduleType = r.ScheduleType ?? e.ScheduleType;
            e.Difficulty = r.Difficulty ?? e.Difficulty;
            e.IsHidden = r.IsHidden ?? e.IsHidden;
            return e;
        }
    }
}
