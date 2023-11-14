using CourseManagement.Data.Models;
using CourseManagement.Data.Repositories;
using CourseManagement.IntegrationEvents.Events;
using Infrastructure.EventBus.Generic.IntegrationEvents;

namespace CourseManagement.IntegrationEvents.Handlers
{
    public class UserEmailChangedIntegrationEventHandler : IIntegrationEventHandler<UserEmailChangedIntegrationEvent>
    {
        private readonly IRepository<Creator> repository;

        public UserEmailChangedIntegrationEventHandler(IRepository<Creator> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(UserEmailChangedIntegrationEvent @event)
        {
            Creator? creator = repository.Get(@event.UserId);
            if (creator != null && creator.Email == @event.OldEmail)
            {
                creator.Email = @event.NewEmail;
                creator.NormalizedEmail = @event.NewEmail.ToUpper();
                repository.Update(creator);
            }
        }
    }
}
