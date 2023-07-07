using CourseManagement.Data;
using CourseManagement.Data.Models;
using CourseManagement.IntegrationEvents.Events;
using Infrastructure.EventBus.Generic.IntegrationEvents;

namespace CourseManagement.IntegrationEvents.Handlers
{
    public class CreatorDeletedIntegrationEventHandler : IIntegrationEventHandler<CreatorDeletedIntegrationEvent>
    {
        private readonly CourseDbContext courseDbContext;

        public CreatorDeletedIntegrationEventHandler(CourseDbContext courseDbContext)
        {
            this.courseDbContext = courseDbContext;
        }
        public async Task Handle(CreatorDeletedIntegrationEvent @event)
        {
            Creator? creator = courseDbContext.Creators.FirstOrDefault(x => x.Id == @event.UserId);
            if (creator != null)
            {
                courseDbContext.Creators.Remove(creator);
                courseDbContext.SaveChanges();
            }
        }
    }
}