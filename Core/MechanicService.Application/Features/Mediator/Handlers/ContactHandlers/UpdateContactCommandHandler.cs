namespace MechanicService.Application.Features.Mediator.Handlers.ContactHandlers
{
    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand>
    {
        private readonly IRepository<Contact> _repository;

        public UpdateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            values.Name = request.Name;
            values.Surname = request.Surname;
            values.Email = request.Email;
            values.Subject = request.Subject;
            values.Message = request.Message;
            values.Isread = request.Isread;
            values.SendDate = request.SendDate;
            await _repository.UpdateAsync(values);
        }
    }
}
