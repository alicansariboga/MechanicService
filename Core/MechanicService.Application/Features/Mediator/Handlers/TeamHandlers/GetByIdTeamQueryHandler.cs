namespace MechanicService.Application.Teams.Mediator.Handlers.TeamHandlers
{
    public class GetByIdTeamQueryHandler : IRequestHandler<GetByIdTeamQuery, GetByIdTeamQueryResult>
    {
        private readonly IRepository<Team> _repository;

        public GetByIdTeamQueryHandler(IRepository<Team> repository)
        {
            _repository = repository;
        }

        public async Task<GetByIdTeamQueryResult> Handle(GetByIdTeamQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetByIdTeamQueryResult
            {
                Id = values.Id,
                Name = values.Name,
                Surname = values.Surname,
                Title = values.Title,
                Gender = values.Gender,
                Description = values.Description,
                ImageUrl = values.ImageUrl,
                WorkStartDate = values.WorkStartDate,
            };
        }
    }
}
