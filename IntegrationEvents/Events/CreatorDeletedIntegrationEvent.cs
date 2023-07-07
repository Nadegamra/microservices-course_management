using Infrastructure.EventBus.Generic.IntegrationEvents;

namespace CourseManagement.IntegrationEvents.Events
{
    public class CreatorDeletedIntegrationEvent : IntegrationEvent
    {
        public required int UserId { get; set; }
    }
}