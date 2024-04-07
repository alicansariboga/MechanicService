namespace MechanicService.Application.Features.Mediator.Queries.TeamQueries
{
    public class GetByIdTeamQuery : IRequest<GetByIdTeamQueryResult>
    {
        public GetByIdTeamQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
