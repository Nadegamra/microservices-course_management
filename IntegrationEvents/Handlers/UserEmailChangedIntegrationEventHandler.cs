using CourseManagement.IntegrationEvents.Events;
using CourseManagement.Models;
using Infrastructure.EventBus.Generic.IntegrationEvents;

namespace CourseManagement.IntegrationEvents.Handlers
{
    public class UserEmailChangedIntegrationEventHandler : IIntegrationEventHandler<UserEmailChangedIntegrationEvent>
    {
        private readonly CourseDbContext courseDbContext;

        public UserEmailChangedIntegrationEventHandler(CourseDbContext courseDbContext)
        {
            this.courseDbContext = courseDbContext;
        }

        public async Task Handle(UserEmailChangedIntegrationEvent @event)
        {
            Creator? creator = courseDbContext.Creators.Where(x=>x.Id == @event.UserId).FirstOrDefault();
            if (creator != null && creator.Email == @event.OldEmail)
            {
                creator.Email = @event.NewEmail;
                creator.NormalizedEmail = @event.NewEmail.ToUpper();
                courseDbContext.Creators.Update(creator);
                await courseDbContext.SaveChangesAsync();
            }
        }
    }
}
