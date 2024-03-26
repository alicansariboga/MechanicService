namespace MechanicService.Application.Features.Mediator.Queries.ServiceQueries
{
    public class GetByIdServiceQuery : IRequest<GetByIdServiceQueryResult>
    {
        public GetByIdServiceQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
