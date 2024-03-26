namespace MechanicService.Application.Features.Mediator.Queries.FeatureQueries
{
    public class GetByIdFeatureQuery : IRequest<GetByIdFeatureQueryResult>
    {
        public GetByIdFeatureQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
