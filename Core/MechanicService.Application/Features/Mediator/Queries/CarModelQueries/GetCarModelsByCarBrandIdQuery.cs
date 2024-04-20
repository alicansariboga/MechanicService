namespace MechanicService.Application.Features.Mediator.Queries.CarModelQueries
{
    public class GetCarModelsByCarBrandIdQuery : IRequest<List<GetCarModelsByCarBrandIdQueryResult>>
    {
        public GetCarModelsByCarBrandIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
