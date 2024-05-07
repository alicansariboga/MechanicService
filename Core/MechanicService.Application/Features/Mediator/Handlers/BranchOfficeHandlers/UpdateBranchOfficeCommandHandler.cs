namespace MechanicService.Application.Features.Mediator.Handlers.BranchOfficeHandlers
{
    public class UpdateBranchOfficeCommandHandler : IRequestHandler<UpdateBranchOfficeCommand>
    {
        private readonly IRepository<BranchOffice> _repository;

        public UpdateBranchOfficeCommandHandler(IRepository<BranchOffice> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBranchOfficeCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            values.Name = request.Name;
            values.Address = request.Address;
            values.Phone = request.Phone;
            values.Email = request.Email;
            values.DistrictId = request.DistrictId;
            values.ImgUrl = request.ImgUrl;
            values.LocationUrl = request.LocationUrl;
            await _repository.UpdateAsync(values);
        }
    }
}
