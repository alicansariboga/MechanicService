namespace MechanicService.Application.Teams.Mediator.Handlers.TeamHandlers
{
    public class RemoveTeamCommandHandler : IRequestHandler<RemoveTeamCommand>
    {
        private readonly IRepository<Team> _repository;

        public RemoveTeamCommandHandler(IRepository<Team> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveTeamCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
