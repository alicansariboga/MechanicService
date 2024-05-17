namespace MechanicService.Application.Features.Mediator.Queries.ServiceQueries
{
    public class GetServiceDescriptionByServiceIdQuery : IRequest<List<GetServiceDescriptionByServiceIdQueryResult>>
    {
        public GetServiceDescriptionByServiceIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
