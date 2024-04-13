namespace MechanicService.Application.Features.Mediator.Commands.ReservationCommands
{
    public class CreateReservationPersonCommand : IRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdentityNumber { get; set; }
        public string Phone { get; set; }
        public string PhoneOpt { get; set; }
        public string Email { get; set; }
    }
}
