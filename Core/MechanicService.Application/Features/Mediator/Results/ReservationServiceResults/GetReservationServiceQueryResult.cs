namespace MechanicService.Application.Features.Mediator.Results.ReservationServiceResults
{
    public class GetReservationServiceQueryResult
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Distinct { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Hour { get; set; }
        public string? Description { get; set; }
    }
}
