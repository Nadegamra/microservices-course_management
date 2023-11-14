using CourseManagement.Data.Models;
using CourseManagement.Data.Repositories;
using CourseManagement.IntegrationEvents.Events;
using Infrastructure.EventBus.Generic.IntegrationEvents;

namespace CourseManagement.IntegrationEvents.Handlers
{
    public class CreatorRegisteredIntegrationEventHandler : IIntegrationEventHandler<CreatorRegisteredIntegrationEvent>
    {
        private readonly IRepository<Creator> repository;

        public CreatorRegisteredIntegrationEventHandler(IRepository<Creator> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(CreatorRegisteredIntegrationEvent @event)
        {
            Creator? creator = new Creator { Id = @event.UserId, Email = @event.Email, NormalizedEmail = @event.Email.ToUpper(), Username = @event.Username, NormalizedUsername = @event.Username.ToUpper(), Bio = "", Website = "" };
            repository.Add(creator);
        }
    }
}