using Infrastructure.EventBus.Generic.IntegrationEvents;

namespace CourseManagement.IntegrationEvents.Events
{
    public class UserEmailChangedIntegrationEvent : IntegrationEvent
    {
        public required int UserId { get; set; }
        public required string OldEmail { get; set; }
        public required string NewEmail { get; set; }
    }
}
