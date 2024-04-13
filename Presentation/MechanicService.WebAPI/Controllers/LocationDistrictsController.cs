namespace MechanicService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationDistrictsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LocationDistrictsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> LocationDistrictList()
        {
            var values = await _mediator.Send(new GetLocationDistrictQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocationDistrict(int id)
        {
            var value = await _mediator.Send(new GetByIdLocationDistrictQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateLocationDistrict(CreateLocationDistrictCommand command)
        {
            await _mediator.Send(command);
            return Ok("Lokasyon İlçe bílgisi basarili bir sekilde eklendi.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveLocationDistrict(int id)
        {
            await _mediator.Send(new RemoveLocationDistrictCommand(id));
            return Ok("Lokasyon İlçe bilgisi basarili bir sekilde silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateLocationDistrict(UpdateLocationDistrictCommand command)
        {
            await _mediator.Send(command);
            return Ok("Lokasyon İlçe bilgisi basarili bir sekilde guncellendi.");
        }
    }
}
