namespace MechanicService.Application.Features.Mediator.Queries.LocationDistrictQueries
{
    public class GetLocationDistrictsByCityIdQuery : IRequest<List<GetLocationDistrictsByCityIdQueryResult>>
    {
        public GetLocationDistrictsByCityIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
