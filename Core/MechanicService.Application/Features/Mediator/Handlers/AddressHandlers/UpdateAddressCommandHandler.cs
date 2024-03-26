namespace MechanicService.Application.Features.Mediator.Handlers.AddressHandlers
{
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand>
    {
        private readonly IRepository<Address> _repository;

        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            values.Description = request.Description;
            values.City = request.City;
            values.District = request.District;
            values.Phone = request.Phone;
            values.PhoneOpt = request.PhoneOpt;
            values.LongAddress = request.LongAddress;
            values.Email = request.Email;
            await _repository.UpdateAsync(values);
        }
    }
}
