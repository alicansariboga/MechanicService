namespace MechanicService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StatisticsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllReservationsCount")]
        public async Task<IActionResult> GetAllReservationsCount()
        {
            var values = await _mediator.Send(new GetAllReservationsCountQuery());
            return Ok(values);
        }
        [HttpGet("GetCompletedReservationsCount")]
        public async Task<IActionResult> GetCompletedReservationsCount()
        {
            var values = await _mediator.Send(new GetCompletedReservationsCountQuery());
            return Ok(values);
        }
        [HttpGet("GetPendingReservationsCount")]
        public async Task<IActionResult> GetPendingReservationsCount()
        {
            var values = await _mediator.Send(new GetPendingReservationsCountQuery());
            return Ok(values);
        }
        [HttpGet("GetAllCustomersCount")]
        public async Task<IActionResult> GetAllCustomersCount()
        {
            var values = await _mediator.Send(new GetAllCustomersCountQuery());
            return Ok(values);
        }
        [HttpGet("GetActiveLocationsCount")]
        public async Task<IActionResult> GetActiveLocationsCount()
        {
            var values = await _mediator.Send(new GetActiveLocationsCountQuery());
            return Ok(values);
        }
        
        [HttpGet("GetReservationsTodayCount")]
        public async Task<IActionResult> GetReservationsTodayCount()
        {
            var values = await _mediator.Send(new GetReservationsTodayCountQuery());
            return Ok(values);
        }
        [HttpGet("GetBrandCount")]
        public async Task<IActionResult> GetBrandCount()
        {
            var values = await _mediator.Send(new GetBrandCountQuery());
            return Ok(values);
        }
        [HttpGet("GetBlogCount")]
        public async Task<IActionResult> GetBlogCount()
        {
            var values = await _mediator.Send(new GetBlogCountQuery());
            return Ok(values);
        }
    }
}
