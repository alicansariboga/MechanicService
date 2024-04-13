namespace MechanicService.Application.Features.Mediator.Queries.LocationCityQueries
{
    public class GetByIdLocationCityQuery : IRequest<GetByIdLocationCityQueryResult>
    {
        public GetByIdLocationCityQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
