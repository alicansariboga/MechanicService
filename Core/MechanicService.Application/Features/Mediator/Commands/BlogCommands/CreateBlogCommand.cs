namespace MechanicService.Application.Features.Mediator.Commands.BlogCommands
{
    public class CreateBlogCommand : IRequest
    {
        public string Title { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }

        public int CategoryID { get; set; }
        public string Description { get; set; }
        public int BlogTime { get; set; }
    }
}
