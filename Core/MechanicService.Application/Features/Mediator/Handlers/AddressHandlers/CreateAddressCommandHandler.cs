namespace MechanicService.Application.Features.Mediator.Handlers.AddressHandlers
{
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand>
    {
        private readonly IRepository<Address> _repository;

        public CreateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Address
            {
                Description = request.Description,
                City = request.City,
                District = request.District,
                Phone = request.Phone,
                PhoneOpt = request.PhoneOpt,
                LongAddress = request.LongAddress,
                Email = request.Email,
            });
        }
    }
}
