namespace MechanicService.Application.Faqs.Mediator.Handlers.FaqHandlers
{
    public class UpdateFaqCommandHandler : IRequestHandler<UpdateFaqCommand>
    {
        private readonly IRepository<Faq> _repository;

        public UpdateFaqCommandHandler(IRepository<Faq> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateFaqCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            values.Title = request.Title;
            values.Description = request.Description;
            values.Category = request.Category;
            await _repository.UpdateAsync(values);
        }
    }
}
