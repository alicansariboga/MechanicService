namespace MechanicService.Application.Faqs.Mediator.Handlers.FaqHandlers
{
    public class GetFaqQueryHandler : IRequestHandler<GetFaqQuery, List<GetFaqQueryResult>>
    {
        private readonly IRepository<Faq> _repository;

        public GetFaqQueryHandler(IRepository<Faq> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetFaqQueryResult>> Handle(GetFaqQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetFaqQueryResult
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Category = x.Category,
            }).ToList();
        }
    }
}
