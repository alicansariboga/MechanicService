namespace MechanicService.Application.Features.Mediator.Queries.ContactQueries
{
    public class GetByIdContactQuery : IRequest<GetByIdContactQueryResult>
    {
        public GetByIdContactQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
