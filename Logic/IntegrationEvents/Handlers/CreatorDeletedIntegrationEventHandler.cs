using CourseManagement.Data.Models;
using CourseManagement.Data.Repositories;
using CourseManagement.IntegrationEvents.Events;
using Infrastructure.EventBus.Generic.IntegrationEvents;

namespace CourseManagement.IntegrationEvents.Handlers
{
    public class CreatorDeletedIntegrationEventHandler : IIntegrationEventHandler<CreatorDeletedIntegrationEvent>
    {
        private readonly IRepository<Creator> repository;

        public CreatorDeletedIntegrationEventHandler(IRepository<Creator> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(CreatorDeletedIntegrationEvent @event)
        {
            Creator? creator = repository.Get(@event.UserId);
            if (creator != null)
            {
                repository.Delete(creator);
            }
        }
    }
}