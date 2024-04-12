namespace MechanicService.Application.Features.Mediator.Commands.CategoryCommands
{
    public class CreateCategoryCommand : IRequest
    {
        public string Name { get; set; }
    }
}
