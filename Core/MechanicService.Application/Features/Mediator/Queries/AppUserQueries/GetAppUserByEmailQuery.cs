

namespace MechanicService.Application.Features.Mediator.Queries.AppUserQueries
{
    public class GetAppUserByEmailQuery : IRequest<GetAppUserByEmailQueryResult>
    {
        public GetAppUserByEmailQuery(string mail)
        {
            Mail = mail;
        }

        public string Mail { get; set; }
    }
}
