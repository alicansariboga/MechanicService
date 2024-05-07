namespace MechanicService.Application.Features.Mediator.Handlers.BranchOfficeHandlers
{
    public class CreateBranchOfficeCommandHandler : IRequestHandler<CreateBranchOfficeCommand>
    {
        private readonly IRepository<BranchOffice> _repository;

        public CreateBranchOfficeCommandHandler(IRepository<BranchOffice> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateBranchOfficeCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new BranchOffice
            {
                Name = request.Name,
                Address = request.Address,
                Phone = request.Phone,
                Email = request.Email,
                DistrictId = request.DistrictId,
                ImgUrl = request.ImgUrl,
                LocationUrl = request.LocationUrl
            });
        }
    }
}
