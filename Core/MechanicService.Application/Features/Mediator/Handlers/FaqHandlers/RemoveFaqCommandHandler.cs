namespace MechanicService.Application.Faqs.Mediator.Handlers.FaqHandlers
{
    public class RemoveFaqCommandHandler : IRequestHandler<RemoveFaqCommand>
    {
        private readonly IRepository<Faq> _repository;

        public RemoveFaqCommandHandler(IRepository<Faq> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveFaqCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
