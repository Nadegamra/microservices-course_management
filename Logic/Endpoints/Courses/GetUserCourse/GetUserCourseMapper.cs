using CourseManagement.Data.Models;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.Courses.GetUserCourse
{
    public class GetUserCourseMapper : ResponseMapper<GetUserCourseResponse, Course>
    {
        public override GetUserCourseResponse FromEntity(Course e)
        {
            return new GetUserCourseResponse()
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
                Routes = RoutesConfig.GetRouteDTOS(
                    "myCourseList","updateCourse","deleteCourse",
                    "getImage","setImage",
                    "addRequirement","removeRequirement","updateRequirement",
                    "addGained","removeGained","updateGained",
                    "addSubtitle","removeSubtitle",
                    "addLanguage", "removeLanguage"
                    )
            };
        }
    }
}
