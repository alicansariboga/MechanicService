namespace MechanicService.Application.Features.Mediator.Handlers.BranchOfficeHandlers
{
    public class RemoveBranchOfficeCommandHandler : IRequestHandler<RemoveBranchOfficeCommand>
    {
        private readonly IRepository<BranchOffice> _repository;

        public RemoveBranchOfficeCommandHandler(IRepository<BranchOffice> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveBranchOfficeCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
