namespace MechanicService.Application.Features.Mediator.Commands.ReservationCommands
{
    public class CreateReservationServiceCommand : IRequest
    {
        public string City { get; set; }
        public string Distinct { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Hour { get; set; }
        public string? Description { get; set; }
        public string ServiceName { get; set; }
    }
}
