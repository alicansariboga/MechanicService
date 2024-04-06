namespace MechanicService.Application.Faqs.Mediator.Handlers.FaqHandlers
{
    public class CreateFaqCommandHandler : IRequestHandler<CreateFaqCommand>
    {
        private readonly IRepository<Faq> _repository;

        public CreateFaqCommandHandler(IRepository<Faq> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateFaqCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Faq
            {
                Title = request.Title,
                Description = request.Description,
                Category = request.Category,
            });
        }
    }
}
