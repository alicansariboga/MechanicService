namespace MechanicService.Application.Features.Mediator.Queries.AboutQueries
{
    public class GetByIdAboutQuery : IRequest<GetByIdAboutQueryResult>
    {
        public GetByIdAboutQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
