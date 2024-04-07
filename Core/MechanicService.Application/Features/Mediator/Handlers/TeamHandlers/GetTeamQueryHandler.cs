namespace MechanicService.Application.Teams.Mediator.Handlers.TeamHandlers
{
    public class GetTeamQueryHandler : IRequestHandler<GetTeamQuery, List<GetTeamQueryResult>>
    {
        private readonly IRepository<Team> _repository;

        public GetTeamQueryHandler(IRepository<Team> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetTeamQueryResult>> Handle(GetTeamQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetTeamQueryResult
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname,
                Title = x.Title,
                Gender = x.Gender,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                WorkStartDate = x.WorkStartDate,
            }).ToList();
        }
    }
}
