using MechanicService.Application.Features.Mediator.Results.AppUserResults;

namespace MechanicService.Application.Features.Mediator.Queries.AppUserQueries
{
    public class GetCheckAppUserQuery : IRequest<GetCheckAppUserQueryResult>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
