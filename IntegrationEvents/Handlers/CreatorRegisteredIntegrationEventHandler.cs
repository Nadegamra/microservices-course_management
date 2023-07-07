using CourseManagement.Data;
using CourseManagement.Data.Models;
using CourseManagement.IntegrationEvents.Events;
using Infrastructure.EventBus.Generic.IntegrationEvents;

namespace CourseManagement.IntegrationEvents.Handlers
{
    public class CreatorRegisteredIntegrationEventHandler : IIntegrationEventHandler<CreatorRegisteredIntegrationEvent>
    {
        private readonly CourseDbContext courseDbContext;

        public CreatorRegisteredIntegrationEventHandler(CourseDbContext courseDbContext)
        {
            this.courseDbContext = courseDbContext;
        }
        public async Task Handle(CreatorRegisteredIntegrationEvent @event)
        {
            Creator? creator = new Creator { Id = @event.UserId, Email = @event.Email, Username = @event.Username };
            courseDbContext.Creators.Add(creator);
            courseDbContext.SaveChanges();
        }
    }
}