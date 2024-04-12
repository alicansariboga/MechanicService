namespace MechanicService.Application.Features.Mediator.Queries.CategoryQueries
{
    public class GetByIdCategoryQuery : IRequest<GetByIdCategoryQueryResult> 
    {
        public GetByIdCategoryQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
