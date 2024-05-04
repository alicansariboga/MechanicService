using MechanicService.Application.Features.Mediator.Commands.AppUserCommands;

namespace MechanicService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RegistersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Registration(CreateAppUserCommand command)
        {
            await _mediator.Send(command);
            return Ok("Kullanıcı başarılı bir şekilde oluşturuldu.");
        }
    }
}
