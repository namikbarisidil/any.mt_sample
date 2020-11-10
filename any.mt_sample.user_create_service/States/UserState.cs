using System;
using Automatonymous;
using MassTransit.Saga;

namespace any.mtsample.user_create_service.States
{
    public class UserState
    : ISagaVersion, SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }
        public int Version { get; set; }

        public string Instance { get; set; }
    }
}