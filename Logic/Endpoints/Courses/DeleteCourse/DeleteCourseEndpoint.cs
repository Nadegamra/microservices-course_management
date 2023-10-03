using CourseManagement.Data;
using CourseManagement.Data.Models;
using CourseManagement.IntegrationEvents.Events;
using FastEndpoints;
using Infrastructure.EventBus.Generic;

namespace CourseManagement.Logic.Endpoints.Courses.DeleteCourse
{
    public class DeleteCourseEndpoint : Endpoint<DeleteCourseRequest, EmptyResponse>
    {
        public override void Configure()
        {
            Delete("courses/{id}");
            Roles("ADMIN", "CREATOR");
        }

        private readonly CourseDbContext courseDbContext;
        private readonly Infrastructure.EventBus.Generic.IEventBus eventBus;

        public DeleteCourseEndpoint(CourseDbContext courseDbContext, Infrastructure.EventBus.Generic.IEventBus eventBus)
        {
            this.courseDbContext = courseDbContext;
            this.eventBus = eventBus;
        }

        public override async Task HandleAsync(DeleteCourseRequest req, CancellationToken ct)
        {
            Course? course = courseDbContext.Courses.Where(x => x.Id == req.Id).FirstOrDefault();
            if (course == null || course.UserId != req.UserId)
            {
                await SendErrorsAsync(400, ct);
                return;
            }

            course.IsDeleted = true;
            var res = courseDbContext.Courses.Update(course);
            courseDbContext.SaveChanges();

            eventBus.Publish(new CourseCreatedIntegrationEvent()
            {
                Id = course.Id,
                UserId = course.UserId
            });

            await SendOkAsync(ct);
        }
    }
}
