namespace MechanicService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaqsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FaqsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> FaqList()
        {
            var values = await _mediator.Send(new GetFaqQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFaq(int id)
        {
            var value = await _mediator.Send(new GetByIdFaqQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFaq(CreateFaqCommand command)
        {
            await _mediator.Send(command);
            return Ok("SSS bílgisi basarili bir sekilde eklendi.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveFaq(int id)
        {
            await _mediator.Send(new RemoveFaqCommand(id));
            return Ok("SSS bilgisi basarili bir sekilde silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFaq(UpdateFaqCommand command)
        {
            await _mediator.Send(command);
            return Ok("SSS bilgisi basarili bir sekilde guncellendi.");
        }
    }
}
