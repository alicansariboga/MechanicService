namespace MechanicService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlogsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> BlogList()
        {
            var values = await _mediator.Send(new GetBlogQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlog(int id)
        {
            var value = await _mediator.Send(new GetByIdBlogQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok("Blog bílgisi basarili bir sekilde eklendi.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveBlog(int id)
        {
            await _mediator.Send(new RemoveBlogCommand(id));
            return Ok("Blog bilgisi basarili bir sekilde silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBlog(UpdateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok("Blog bilgisi basarili bir sekilde guncellendi.");
        }
        [HttpGet("GetLast3BlogsList")]
        public async Task<IActionResult> GetLast3BlogsList()
        {
            var values = await _mediator.Send(new GetLast3BlogsQuery());
            return Ok(values);
        }
        [HttpGet("GetBlogWithCategoryName")]
        public async Task<IActionResult> GetBlogWithCategoryName(int id)
        {
            var values = await _mediator.Send(new GetBlogWithCategoryNameQuery(id));
            return Ok(values);
        }
    }
}
