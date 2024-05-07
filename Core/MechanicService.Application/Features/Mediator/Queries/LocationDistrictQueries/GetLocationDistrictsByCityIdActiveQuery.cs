namespace MechanicService.Application.Features.Mediator.Queries.LocationDistrictQueries
{
    public class GetLocationDistrictsByCityIdActiveQuery : IRequest<List<GetLocationDistrictsByCityIdActiveQueryResult>>
    {
        public GetLocationDistrictsByCityIdActiveQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
