namespace MechanicService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContactsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> ContactList()
        {
            var values = await _mediator.Send(new GetContactQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact(int id)
        {
            var value = await _mediator.Send(new GetByIdContactQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateContactId(CreateContactCommand command)
        {
            await _mediator.Send(command);
            return Ok("İletişim bílgisi basarili bir sekilde eklendi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateContact(UpdateContactCommand command)
        {
            await _mediator.Send(command);
            return Ok("İletişim bilgisi basarili bir sekilde guncellendi.");
        }
    }
}
