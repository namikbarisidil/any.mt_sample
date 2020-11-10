using System.Threading.Tasks;
using MassTransit;
using Contracts.ContractMessages;
using Microsoft.AspNetCore.Mvc;

namespace MassTransitWebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IRequestClient<ICreateUser> _createUser;
        private readonly IPublishEndpoint _publishEndpoint;

        public UserController(IRequestClient<ICreateUser> createUser, IPublishEndpoint publishEndpoint)
        {
            _createUser = createUser;
            _publishEndpoint = publishEndpoint;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string username)
        {
            var (accepted, faulted) = await _createUser.GetResponse<IUserCreated, IUserCreatedFault>(new
            {
                Username = username,
                Password = "Ulus"
            });

            // await _publishEndpoint.Publish<ICreateUser>(new
            // {
            //     Username = "Umut",
            //     Password = "Ulus"
            // });

            if (accepted.IsCompletedSuccessfully)
            {
                var message = (await accepted).Message.Result;
                return Ok(message);
            }
            else
            {
                var message = (await faulted).Message.FaultReason;
                return BadRequest(message);
            }
        }
    }
}
