namespace MechanicService.Application.Features.Mediator.Queries.CarModelQueries
{
    public class GetByIdCarModelQuery : IRequest<GetByIdCarModelQueryResult>
    {
        public GetByIdCarModelQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
