using CourseManagement.Data.Models;
using CourseManagement.Data.Repositories;
using CourseManagement.IntegrationEvents.Events;
using Infrastructure.EventBus.Generic.IntegrationEvents;

namespace CourseManagement.IntegrationEvents.Handlers
{
    public class UserNameChangedIntegrationEventHandler : IIntegrationEventHandler<UserNameChangedIntegrationEvent>
    {
        private readonly IRepository<Creator> repository;

        public UserNameChangedIntegrationEventHandler(IRepository<Creator> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(UserNameChangedIntegrationEvent @event)
        {
            Creator? creator = repository.Get(@event.UserId);
            if (creator != null && creator.Username == @event.OldUserName)
            {
                creator.Username = @event.NewUserName;
                creator.NormalizedUsername = @event.NewUserName.ToUpper();
                repository.Update(creator);
            }
        }
    }
}
