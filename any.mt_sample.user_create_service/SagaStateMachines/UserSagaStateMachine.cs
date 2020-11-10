using any.mtsample.user_create_service.States;
using Automatonymous;
using Contracts.ContractMessages;

namespace any.mtsample.user_create_service.SagaStateMachines
{
    public class UserSagaStateMachine
    : MassTransitStateMachine<UserState>
    {
        public UserSagaStateMachine()
        {
            
        }

        public Event<ICreateUser> CreateUserEvent { get; set; }

        public State IUserCreated { get; set; }
    }
}