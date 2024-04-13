namespace MechanicService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationServicesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReservationServicesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> ReservationServiceList()
        {
            var values = await _mediator.Send(new GetReservationServiceQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservationService(int id)
        {
            var value = await _mediator.Send(new GetByIdReservationServiceQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateReservationService(CreateReservationServiceCommand command)
        {
            await _mediator.Send(command);
            return Ok("Rezervasyon servis bílgisi basarili bir sekilde eklendi.");
        }
    }
}
