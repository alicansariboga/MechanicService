namespace MechanicService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarModelsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarModelsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> CarModelList()
        {
            var values = await _mediator.Send(new GetCarModelQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarModel(int id)
        {
            var value = await _mediator.Send(new GetByIdCarModelQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCarModel(CreateCarModelCommand command)
        {
            await _mediator.Send(command);
            return Ok("Model bílgisi basarili bir sekilde eklendi.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCarModel(int id)
        {
            await _mediator.Send(new RemoveCarModelCommand(id));
            return Ok("Model bilgisi basarili bir sekilde silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCarModel(UpdateCarModelCommand command)
        {
            await _mediator.Send(command);
            return Ok("Model bilgisi basarili bir sekilde guncellendi.");
        }
    }
}
