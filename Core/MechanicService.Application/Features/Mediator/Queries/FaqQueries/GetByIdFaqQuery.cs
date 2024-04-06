namespace MechanicService.Application.Features.Mediator.Queries.FaqQueries
{
    public class GetByIdFaqQuery : IRequest<GetByIdFaqQueryResult>
    {
        public GetByIdFaqQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
