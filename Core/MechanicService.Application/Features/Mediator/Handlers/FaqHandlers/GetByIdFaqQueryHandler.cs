namespace MechanicService.Application.Faqs.Mediator.Handlers.FaqHandlers
{
    public class GetByIdFaqQueryHandler : IRequestHandler<GetByIdFaqQuery, GetByIdFaqQueryResult>
    {
        private readonly IRepository<Faq> _repository;

        public GetByIdFaqQueryHandler(IRepository<Faq> repository)
        {
            _repository = repository;
        }

        public async Task<GetByIdFaqQueryResult> Handle(GetByIdFaqQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetByIdFaqQueryResult
            {
                Id = values.Id,
                Title = values.Title,
                Description = values.Description,
                Category = values.Category,
            };
        }
    }
}
