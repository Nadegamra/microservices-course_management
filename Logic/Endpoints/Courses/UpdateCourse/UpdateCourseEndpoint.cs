using CourseManagement.Data.Models;
using CourseManagement.Data.Repositories;
using CourseManagement.IntegrationEvents.Events;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.Courses.UpdateCourse
{
    public class UpdateCourseEndpoint : Endpoint<UpdateCourseRequest, UpdateCourseResponse, UpdateCourseMapper>
    {
        public override void Configure()
        {
            Put("courses/{id}");
            Roles("ADMIN", "CREATOR");
        }

        private readonly IRepository<Course> repository;
        private readonly Infrastructure.EventBus.Generic.IEventBus eventBus;

        public UpdateCourseEndpoint(Infrastructure.EventBus.Generic.IEventBus eventBus, IRepository<Course> repository)
        {
            this.eventBus = eventBus;
            this.repository = repository;
        }

        public override async Task HandleAsync(UpdateCourseRequest req, CancellationToken ct)
        {
            Course? original = repository.GetAll()
                                .Where(x => x.Id == req.Id && x.UserId == req.UserId)
                                .FirstOrDefault();
            if (original == null)
            {
                await SendErrorsAsync(418, ct);
                return;
            }

            Course updated = Map.UpdateEntity(req, original);
            var res = repository.Update(updated);

            Response = Map.FromEntity(res);

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
