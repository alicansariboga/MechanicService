namespace MechanicService.Application.Features.Mediator.Queries.BlogQueries
{
    public class GetByIdBlogQuery : IRequest<GetByIdBlogQueryResult>
    {
        public GetByIdBlogQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
