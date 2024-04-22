namespace MechanicService.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetUnreadMessagesCountQueryHandler : IRequestHandler<GetUnreadMessagesCountQuery, GetUnreadMessagesCountQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetUnreadMessagesCountQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetUnreadMessagesCountQueryResult> Handle(GetUnreadMessagesCountQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetUnreadMessagesCount();
            return new GetUnreadMessagesCountQueryResult
            {
                GetUnreadMessagesCount = values,
            };
        }
    }
}
