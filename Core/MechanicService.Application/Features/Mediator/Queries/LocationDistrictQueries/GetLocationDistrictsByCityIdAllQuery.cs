namespace MechanicService.Application.Features.Mediator.Queries.LocationDistrictQueries
{
    public class GetLocationDistrictsByCityIdAllQuery : IRequest<List<GetLocationDistrictsByCityIdAllQueryResult>>
    {
        public GetLocationDistrictsByCityIdAllQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
