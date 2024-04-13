namespace MechanicService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationCitiesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LocationCitiesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> LocationCityList()
        {
            var values = await _mediator.Send(new GetLocationCityQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocationCity(int id)
        {
            var value = await _mediator.Send(new GetByIdLocationCityQuery(id));
            return Ok(value);
        }
    }
}
