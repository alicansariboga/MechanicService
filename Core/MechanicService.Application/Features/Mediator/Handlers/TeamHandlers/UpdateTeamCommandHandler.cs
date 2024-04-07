namespace MechanicService.Application.Teams.Mediator.Handlers.TeamHandlers
{
    public class UpdateTeamCommandHandler : IRequestHandler<UpdateTeamCommand>
    {
        private readonly IRepository<Team> _repository;

        public UpdateTeamCommandHandler(IRepository<Team> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateTeamCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            values.Name = request.Name;
            values.Surname = request.Surname;
            values.Title = request.Title;
            values.Gender = request.Gender;
            values.Description = request.Description;
            values.ImageUrl = request.ImageUrl;
            values.WorkStartDate = request.WorkStartDate;
            await _repository.UpdateAsync(values);
        }
    }
}
