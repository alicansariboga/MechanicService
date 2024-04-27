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
        [HttpGet]
        public async Task<IActionResult> CustomerList()
        {
            var values = await _mediator.Send(new GetCustomersByReservationPersonIdQuery());
            return Ok(values);
        }
    }
}
