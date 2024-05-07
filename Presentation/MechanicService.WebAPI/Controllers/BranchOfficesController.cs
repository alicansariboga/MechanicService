namespace MechanicService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchOfficesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BranchOfficesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> BranchOfficeList()
        {
            var values = await _mediator.Send(new GetBranchOfficeQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBranchOffice(int id)
        {
            var value = await _mediator.Send(new GetByIdBranchOfficeQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBranchOffice(CreateBranchOfficeCommand command)
        {
            await _mediator.Send(command);
            return Ok("Şube bílgisi basarili bir sekilde eklendi.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveBranchOffice(int id)
        {
            await _mediator.Send(new RemoveBranchOfficeCommand(id));
            return Ok("Şube bilgisi basarili bir sekilde silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBranchOffice(UpdateBranchOfficeCommand command)
        {
            await _mediator.Send(command);
            return Ok("Şube bilgisi basarili bir sekilde guncellendi.");
        }
    }
}
