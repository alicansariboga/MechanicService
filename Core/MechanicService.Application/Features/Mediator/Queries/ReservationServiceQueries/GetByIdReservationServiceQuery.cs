namespace MechanicService.Application.Features.Mediator.Queries.ReservationServiceQueries
{
    public class GetByIdReservationServiceQuery : IRequest<GetByIdReservationServiceQueryResult>
    {
        public GetByIdReservationServiceQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
