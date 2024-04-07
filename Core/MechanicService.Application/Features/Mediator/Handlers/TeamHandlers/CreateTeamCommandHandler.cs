namespace MechanicService.Application.Teams.Mediator.Handlers.TeamHandlers
{
    public class CreateTeamCommandHandler : IRequestHandler<CreateTeamCommand>
    {
        private readonly IRepository<Team> _repository;

        public CreateTeamCommandHandler(IRepository<Team> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateTeamCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Team
            {
                Name = request.Name,
                Surname = request.Surname,
                Title = request.Title,
                Gender = request.Gender,
                Description = request.Description,
                ImageUrl = request.ImageUrl,
                WorkStartDate = request.WorkStartDate,
            });
        }
    }
}
