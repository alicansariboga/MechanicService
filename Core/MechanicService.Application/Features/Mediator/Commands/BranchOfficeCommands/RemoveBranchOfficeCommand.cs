namespace MechanicService.Application.Features.Mediator.Commands.BranchOfficeCommands
{
    public class RemoveBranchOfficeCommand : IRequest
    {
        public RemoveBranchOfficeCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
