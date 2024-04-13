namespace MechanicService.Application.Features.Mediator.Queries.ReservationQueries
{
    public class GetByIdReservationQuery : IRequest<GetByIdReservationQueryResult>
    {
        public GetByIdReservationQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
