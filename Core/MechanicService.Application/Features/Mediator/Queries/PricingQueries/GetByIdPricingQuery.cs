namespace MechanicService.Application.Features.Mediator.Queries.PricingQueries
{
    public class GetByIdPricingQuery : IRequest<GetByIdPricingQueryResult>
    {
        public GetByIdPricingQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
