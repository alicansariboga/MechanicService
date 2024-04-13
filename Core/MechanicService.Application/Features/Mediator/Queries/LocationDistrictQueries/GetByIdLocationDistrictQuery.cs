namespace MechanicService.Application.Features.Mediator.Queries.LocationDistrictQueries
{
    public class GetByIdLocationDistrictQuery : IRequest<GetByIdLocationDistrictQueryResult>
    {
        public GetByIdLocationDistrictQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
