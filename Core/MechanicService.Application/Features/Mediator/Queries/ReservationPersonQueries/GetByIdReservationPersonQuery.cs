namespace MechanicService.Application.Features.Mediator.Queries.ReservationPersonQueries
{
    public class GetByIdReservationPersonQuery : IRequest<GetByIdReservationPersonQueryResult>
    {
        public GetByIdReservationPersonQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
