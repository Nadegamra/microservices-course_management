using Infrastructure.EventBus.Generic.IntegrationEvents;

namespace CourseManagement.IntegrationEvents.Events
{
    public class CourseUpdatedIntegrationEvent : IntegrationEvent
    {
        public required int Id { get; set; }
        public bool? IsHidden { get; set; }
        public bool? IsDeleted { get; set; }
    }
}