namespace MechanicService.Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class GetByIdServiceQueryHandler : IRequestHandler<GetByIdServiceQuery, GetByIdServiceQueryResult>
    {
        private readonly IRepository<Service> _repository;

        public GetByIdServiceQueryHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task<GetByIdServiceQueryResult> Handle(GetByIdServiceQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetByIdServiceQueryResult
            {
                Id = values.Id,
                Title = values.Title,
                Description = values.Description,
                IconUrl = values.IconUrl,
            };
        }
    }
}
