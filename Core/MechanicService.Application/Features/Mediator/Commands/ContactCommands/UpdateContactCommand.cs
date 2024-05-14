namespace MechanicService.Application.Features.Mediator.Commands.ContactCommands
{
    public class UpdateContactCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public bool Isread { get; set; }
        public DateTime SendDate { get; set; }
    }
}
