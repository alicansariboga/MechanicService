namespace MechanicService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PricingsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> PricingList()
        {
            var values = await _mediator.Send(new GetPricingQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPricing(int id)
        {
            var value = await _mediator.Send(new GetByIdPricingQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePricing(CreatePricingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Ücret bílgisi basarili bir sekilde eklendi.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemovePricing(int id)
        {
            await _mediator.Send(new RemovePricingCommand(id));
            return Ok("Ücret bilgisi basarili bir sekilde silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePricing(UpdatePricingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Ücret bilgisi basarili bir sekilde guncellendi.");
        }
    }
}
