namespace MechanicService.Application.Features.Mediator.Queries.CarBrandQueries
{
    public class GetByIdCarBrandQuery : IRequest<GetByIdCarBrandQueryResult>
    {
        public GetByIdCarBrandQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
