namespace MechanicService.Application.Features.Mediator.Queries.ReservationCarQueries
{
    public class GetByIdReservationCarQuery : IRequest<GetByIdReservationCarQueryResult>
    {
        public GetByIdReservationCarQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
