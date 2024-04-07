namespace MechanicService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TeamsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> TeamList()
        {
            var values = await _mediator.Send(new GetTeamQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeam(int id)
        {
            var value = await _mediator.Send(new GetByIdTeamQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTeam(CreateTeamCommand command)
        {
            await _mediator.Send(command);
            return Ok("Takım bílgisi basarili bir sekilde eklendi.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveTeam(int id)
        {
            await _mediator.Send(new RemoveTeamCommand(id));
            return Ok("Takım bilgisi basarili bir sekilde silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTeam(UpdateTeamCommand command)
        {
            await _mediator.Send(command);
            return Ok("Takım bilgisi basarili bir sekilde guncellendi.");
        }
    }
}
