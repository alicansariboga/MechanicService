namespace MechanicService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("CustomerList")]
        public async Task<IActionResult> CustomerList()
        {
            var values = await _mediator.Send(new GetCustomersByReservationIdQuery());
            return Ok(values);
        }
        [HttpGet("CustomersReservationsList")]
        public async Task<IActionResult> CustomersReservationsList()
        {
            var values = await _mediator.Send(new GetCustomersAllReservationsByReservationIdQuery());
            return Ok(values);
        }
    }
}
