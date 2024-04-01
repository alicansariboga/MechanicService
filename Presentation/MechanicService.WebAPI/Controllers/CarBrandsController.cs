namespace MechanicService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarBrandsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarBrandsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> CarBrandList()
        {
            var values = await _mediator.Send(new GetCarBrandQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarBrand(int id)
        {
            var value = await _mediator.Send(new GetByIdCarBrandQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCarBrand(CreateCarBrandCommand command)
        {
            await _mediator.Send(command);
            return Ok("Marka bílgisi basarili bir sekilde eklendi.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCarBrand(int id)
        {
            await _mediator.Send(new RemoveCarBrandCommand(id));
            return Ok("Marka bilgisi basarili bir sekilde silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCarBrand(UpdateCarBrandCommand command)
        {
            await _mediator.Send(command);
            return Ok("Marka bilgisi basarili bir sekilde guncellendi.");
        }
    }
}
