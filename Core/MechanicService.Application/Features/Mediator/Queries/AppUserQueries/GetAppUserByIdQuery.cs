namespace MechanicService.Application.Features.Mediator.Queries.AppUserQueries
{
    public class GetAppUserByIdQuery : IRequest<GetAppUserByIdQueryResult>
    {
        public GetAppUserByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
