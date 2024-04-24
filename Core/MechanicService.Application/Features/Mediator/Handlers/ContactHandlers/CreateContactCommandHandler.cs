namespace MechanicService.Application.Features.Mediator.Handlers.ContactHandlers
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand>
    {
        private readonly IRepository<Contact> _repository;

        public CreateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Contact
            {
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
                Subject = request.Subject,
                Message = request.Message,
                Isread = request.Isread,
                SendDate = request.SendDate,
            });
        }
    }
}
