using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.EventBus.Generic.IntegrationEvents;

namespace CourseManagement.IntegrationEvents.Events
{
    public class CourseDeletedIntegrationEvent : IntegrationEvent
    {
        public required int Id { get; set; }
    }
}