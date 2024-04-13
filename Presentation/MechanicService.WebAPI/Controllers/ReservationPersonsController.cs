namespace MechanicService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationPersonsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReservationPersonsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> ReservationPersonList()
        {
            var values = await _mediator.Send(new GetReservationPersonQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservationPerson(int id)
        {
            var value = await _mediator.Send(new GetByIdReservationPersonQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateReservationPerson(CreateReservationPersonCommand command)
        {
            await _mediator.Send(command);
            return Ok("Rezervasyon kişi bílgisi basarili bir sekilde eklendi.");
        }
    }
}
