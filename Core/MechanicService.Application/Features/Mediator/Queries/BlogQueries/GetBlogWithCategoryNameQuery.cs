namespace MechanicService.Application.Features.Mediator.Queries.BlogQueries
{
    public class GetBlogWithCategoryNameQuery : IRequest<GetBlogWithCategoryNameQueryResult>
    {
        public GetBlogWithCategoryNameQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
