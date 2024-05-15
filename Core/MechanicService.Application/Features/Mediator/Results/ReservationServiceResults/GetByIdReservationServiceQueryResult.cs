namespace MechanicService.Application.Features.Mediator.Results.ReservationServiceResults
{
    public class GetByIdReservationServiceQueryResult
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Distinct { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Hour { get; set; }
        public string? Description { get; set; }
        public string ServiceName { get; set; }
    }
}
