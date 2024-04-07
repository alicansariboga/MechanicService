namespace MechanicService.Application.Features.Mediator.Queries.LocationQueries
{
    public class GetByIdLocationQuery : IRequest<GetByIdLocationQueryResult>
    {
        public GetByIdLocationQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
