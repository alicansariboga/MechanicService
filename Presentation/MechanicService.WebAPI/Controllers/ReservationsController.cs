﻿namespace MechanicService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReservationsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> ReservationList()
        {
            var values = await _mediator.Send(new GetReservationQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservation(int id)
        {
            var value = await _mediator.Send(new GetByIdReservationQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateReservation(CreateReservationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Rezervasyon bílgisi basarili bir sekilde eklendi.");
        }
        [HttpGet("GetReservationCarId")]
        public async Task<IActionResult> GetReservationCarId()
        {
            var values = await _mediator.Send(new GetReservationCarIdQuery());
            return Ok(values);
        }
        [HttpGet("GetReservationPerson")]
        public async Task<IActionResult> GetReservationPerson()
        {
            var values = await _mediator.Send(new GetReservationPersonIdQuery());
            return Ok(values);
        }
        [HttpGet("GetReservationService")]
        public async Task<IActionResult> GetReservationService()
        {
            var values = await _mediator.Send(new GetReservationServiceIdQuery());
            return Ok(values);
        }
    }
}