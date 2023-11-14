using CourseManagement.Data.Models;
using CourseManagement.Data.Repositories;
using CourseManagement.IntegrationEvents.Events;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.Courses.DeleteCourse
{
    public class DeleteCourseEndpoint : Endpoint<DeleteCourseRequest, EmptyResponse>
    {
        public override void Configure()
        {
            Delete("courses/{id}");
            Roles("ADMIN", "CREATOR");
        }

        private readonly IRepository<Course> repository;
        private readonly Infrastructure.EventBus.Generic.IEventBus eventBus;

        public DeleteCourseEndpoint(Infrastructure.EventBus.Generic.IEventBus eventBus, IRepository<Course> repository)
        {
            this.eventBus = eventBus;
            this.repository = repository;
        }

        public override async Task HandleAsync(DeleteCourseRequest req, CancellationToken ct)
        {
            Course? course = repository.Get(req.Id);
            if (course == null || course.UserId != req.UserId)
            {
                await SendErrorsAsync(400, ct);
                return;
            }

            course.IsDeleted = true;
            var res = repository.Update(course);

            eventBus.Publish(new CourseCreatedIntegrationEvent()
            {
                Id = course.Id,
                UserId = course.UserId
            });

            await SendNoContentAsync(ct);
        }
    }
}
