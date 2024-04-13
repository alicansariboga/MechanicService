namespace MechanicService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationCarsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReservationCarsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> ReservationCarList()
        {
            var values = await _mediator.Send(new GetReservationCarQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservationCar(int id)
        {
            var value = await _mediator.Send(new GetByIdReservationCarQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateReservationCar(CreateReservationCarCommand command)
        {
            await _mediator.Send(command);
            return Ok("Rezervasyon araba bílgisi basarili bir sekilde eklendi.");
        }
    }
}
