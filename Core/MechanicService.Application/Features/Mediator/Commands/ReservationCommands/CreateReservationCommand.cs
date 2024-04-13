namespace MechanicService.Application.Features.Mediator.Commands.ReservationCommands
{
    public class CreateReservationCommand : IRequest
    {
        public int RezCarID { get; set; }
        public int RezPersonID { get; set; }
        public int RezServiceID { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsApproved { get; set; }
        public bool IsCanceled { get; set; }
    }
}
