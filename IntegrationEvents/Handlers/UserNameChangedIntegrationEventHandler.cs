using CourseManagement.IntegrationEvents.Events;
using CourseManagement.Models;
using Infrastructure.EventBus.Generic.IntegrationEvents;

namespace CourseManagement.IntegrationEvents.Handlers
{
    public class UserNameChangedIntegrationEventHandler : IIntegrationEventHandler<UserNameChangedIntegrationEvent>
    {
        private readonly CourseDbContext courseDbContext;

        public UserNameChangedIntegrationEventHandler(CourseDbContext courseDbContext)
        {
            this.courseDbContext = courseDbContext;
        }

        public async Task Handle(UserNameChangedIntegrationEvent @event)
        {
            Creator? creator = courseDbContext.Creators.Where(x => x.Id == @event.UserId).FirstOrDefault();
            if (creator != null && creator.Username == @event.OldUserName)
            {
                creator.Username = @event.NewUserName;
                creator.NormalizedUsername = @event.NewUserName.ToUpper();
                courseDbContext.Creators.Update(creator);
                await courseDbContext.SaveChangesAsync();
            }
        }
    }
}
