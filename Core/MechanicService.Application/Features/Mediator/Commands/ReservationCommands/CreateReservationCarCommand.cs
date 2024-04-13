namespace MechanicService.Application.Features.Mediator.Commands.ReservationCommands
{
    public class CreateReservationCarCommand : IRequest
    {
        public int ModelID { get; set; }
        public int Year { get; set; }
        public string LicensePlate { get; set; }
        public int Km { get; set; }
    }
}
