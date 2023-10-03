using CourseManagement.Data;
using CourseManagement.Data.Models;
using CourseManagement.IntegrationEvents.Events;
using FastEndpoints;
using Infrastructure.EventBus.Generic;

namespace CourseManagement.Logic.Endpoints.Courses.UpdateCourse
{
    public class UpdateCourseEndpoint : Endpoint<UpdateCourseRequest, UpdateCourseResponse, UpdateCourseMapper>
    {
        public override void Configure()
        {
            Put("courses/{id}");
            Roles("ADMIN", "CREATOR");
        }

        private readonly CourseDbContext courseDbContext;
        private readonly Infrastructure.EventBus.Generic.IEventBus eventBus;

        public UpdateCourseEndpoint(CourseDbContext courseDbContext, Infrastructure.EventBus.Generic.IEventBus eventBus)
        {
            this.courseDbContext = courseDbContext;
            this.eventBus = eventBus;
        }

        public override async Task HandleAsync(UpdateCourseRequest req, CancellationToken ct)
        {
            Course? original = courseDbContext.Courses.Where(x => x.Id == req.Id && x.UserId == req.UserId).FirstOrDefault();
            if (original == null)
            {
                await SendErrorsAsync(418, ct);
                return;
            }

            Course updated = Map.UpdateEntity(req, original);
            var res = courseDbContext.Courses.Update(updated);
            courseDbContext.SaveChanges();

            Response = Map.FromEntity(res.Entity);

            eventBus.Publish(new CourseUpdatedIntegrationEvent()
            {
                Id = updated.Id,
                IsHidden = updated.IsHidden,
                IsDeleted = updated.IsDeleted
            });

            await SendOkAsync(Response, ct);
        }
    }
}
